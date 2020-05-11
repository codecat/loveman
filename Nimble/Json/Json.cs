/*
The MIT License

Copyright (c) 2008 NHaml Project

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

// Source: https://code.google.com/p/nhaml/source/browse/trunk/src/Tests/HamlSpec/JSON.cs

// Modified for better error reporting in Nimble Software

using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace Nimble.JSON
{
  /// <summary>
  /// This class encodes and decodes JSON strings.
  /// Spec. details, see http://www.json.org/
  /// 
  /// JSON uses Arrays and Objects. These correspond here to the datatypes ArrayList and Hashtable.
  /// All numbers are parsed to doubles.
  /// </summary>
  public class Json
  {
    internal enum JSONToken
    {
      NONE = 0,
      CURLY_OPEN = 1,
      CURLY_CLOSE = 2,
      SQUARED_OPEN = 3,
      SQUARED_CLOSE = 4,
      COLON = 5,
      COMMA = 6,
      STRING = 7,
      NUMBER = 8,
      TRUE = 9,
      FALSE = 10,
      NULL = 11,
    }

    private const int BUILDER_CAPACITY = 2000;

    private static int LastLineIndex = 0;

    /// <summary>
    /// Parses the string json into a value.
    /// </summary>
    /// <param name="json">A JSON string.</param>
    /// <returns>An ArrayList, a Hashtable, a double, a string, null, true, or false</returns>
    public static object JsonDecode(string json)
    {
      if (json != null) {
        char[] charArray = json.ToCharArray();
        LastLineIndex = 0;
        int index = 0;
        int line = 1;
        object value = ParseValue(charArray, ref index, ref line);
        return value;
      } else {
        return null;
      }
    }

    /// <summary>
    /// Converts a Hashtable / ArrayList object into a JSON string
    /// </summary>
    /// <param name="json">A Hashtable / ArrayList</param>
    /// <returns>A JSON encoded string, or null if object 'json' is not serializable</returns>
    public static string JsonEncode(object json)
    {
      StringBuilder builder = new StringBuilder(BUILDER_CAPACITY);
      SerializeValue(json, builder);
      return builder.ToString();
    }

    internal static Hashtable ParseObject(char[] json, ref int index, ref int line)
    {
      Hashtable table = new Hashtable();
      JSONToken token;

      // {
      NextToken(json, ref index, ref line);

      bool done = false;
      while (!done) {
        token = LookAhead(json, index, ref line);
        if (token == JSONToken.NONE) {
          throw new JsonException("Invalid token found while parsing object.", index, line);
        } else if (token == JSONToken.COMMA) {
          NextToken(json, ref index, ref line);
        } else if (token == JSONToken.CURLY_CLOSE) {
          NextToken(json, ref index, ref line);
          return table;
        } else {

          // name
          string name = ParseString(json, ref index, ref line);

          // :
          token = NextToken(json, ref index, ref line);
          if (token != JSONToken.COLON) {
            throw new JsonException("Colon expected after object key name.", index, line);
          }

          // value
          object value = ParseValue(json, ref index, ref line);

          table[name] = value;
        }
      }

      return table;
    }

    internal static ArrayList ParseArray(char[] json, ref int index, ref int line)
    {
      ArrayList array = new ArrayList();

      // [
      NextToken(json, ref index, ref line);

      bool done = false;
      while (!done) {
        JSONToken token = LookAhead(json, index, ref line);
        if (token == JSONToken.NONE) {
          throw new JsonException("Invalid token found while parsing array.", index, line);
        } else if (token == JSONToken.COMMA) {
          NextToken(json, ref index, ref line);
        } else if (token == JSONToken.SQUARED_CLOSE) {
          NextToken(json, ref index, ref line);
          break;
        } else {
          object value = ParseValue(json, ref index, ref line);

          array.Add(value);
        }
      }

      return array;
    }

    internal static object ParseValue(char[] json, ref int index, ref int line)
    {
      JSONToken token = LookAhead(json, index, ref line);
      switch (token) {
        case JSONToken.STRING:
          return ParseString(json, ref index, ref line);
        case JSONToken.NUMBER:
          return ParseNumber(json, ref index, ref line);
        case JSONToken.CURLY_OPEN:
          return ParseObject(json, ref index, ref line);
        case JSONToken.SQUARED_OPEN:
          return ParseArray(json, ref index, ref line);
        case JSONToken.TRUE:
          NextToken(json, ref index, ref line);
          return Boolean.Parse("TRUE");
        case JSONToken.FALSE:
          NextToken(json, ref index, ref line);
          return Boolean.Parse("FALSE");
        case JSONToken.NULL:
          NextToken(json, ref index, ref line);
          return null;
        case JSONToken.NONE:
          break;
      }

      throw new JsonException("Invalid token found while parsing value.", index, line);
    }

    internal static string ParseString(char[] json, ref int index, ref int line)
    {
      StringBuilder s = new StringBuilder(BUILDER_CAPACITY);
      char c;
      int startIndex = index;
      int startLine = line;

      EatWhitespace(json, ref index, ref line);

      // "
      c = json[index++];

      bool complete = false;
      while (!complete) {

        if (index == json.Length) {
          break;
        }

        c = json[index++];
        if (c == '"') {
          complete = true;
          break;
        } else if (c == '\\') {

          if (index == json.Length) {
            break;
          }
          c = json[index++];
          if (c == '"') {
            s.Append('"');
          } else if (c == '\\') {
            s.Append('\\');
          } else if (c == '/') {
            s.Append('/');
          } else if (c == 'b') {
            s.Append('\b');
          } else if (c == 'f') {
            s.Append('\f');
          } else if (c == 'n') {
            s.Append('\n');
          } else if (c == 'r') {
            s.Append('\r');
          } else if (c == 't') {
            s.Append('\t');
          } else if (c == 'u') {
            int remainingLength = json.Length - index;
            if (remainingLength >= 4) {
              // fetch the next 4 chars
              char[] unicodeCharArray = new char[4];
              Array.Copy(json, index, unicodeCharArray, 0, 4);
              // parse the 32 bit hex into an integer codepoint
              uint codePoint = UInt32.Parse(new string(unicodeCharArray), NumberStyles.HexNumber);
              // convert the integer codepoint to a unicode char and add to string
              try {
                s.Append(Char.ConvertFromUtf32((int)codePoint));
              } catch { }
              // skip 4 chars
              index += 4;
            } else {
              break;
            }
          }

        } else {
          s.Append(c);
        }

      }

      if (!complete) {
        throw new JsonException("Unterminated string.", startIndex, startLine);
      }

      return s.ToString();
    }

    internal static double ParseNumber(char[] json, ref int index, ref int line)
    {
      EatWhitespace(json, ref index, ref line);

      int lastIndex = GetLastIndexOfNumber(json, index);
      int charLength = (lastIndex - index) + 1;
      char[] numberCharArray = new char[charLength];

      Array.Copy(json, index, numberCharArray, 0, charLength);
      index = lastIndex + 1;
      return Double.Parse(new string(numberCharArray), CultureInfo.InvariantCulture);
    }

    internal static int GetLastIndexOfNumber(char[] json, int index)
    {
      int lastIndex;

      for (lastIndex = index; lastIndex < json.Length; lastIndex++) {
        if ("0123456789+-.eE".IndexOf(json[lastIndex]) == -1) {
          break;
        }
      }
      return lastIndex - 1;
    }

    internal static void EatWhitespace(char[] json, ref int index, ref int line)
    {
      for (; index < json.Length; index++) {
        if (" \t\n\r".IndexOf(json[index]) == -1) {
          break;
        }
        if (json[index] == '\n') {
          if (index <= LastLineIndex) {
            continue;
          }
          line++;
          LastLineIndex = index;
        }
      }
    }

    internal static JSONToken LookAhead(char[] json, int index, ref int line)
    {
      int saveIndex = index;
      return NextToken(json, ref saveIndex, ref line);
    }

    internal static JSONToken NextToken(char[] json, ref int index, ref int line)
    {
      EatWhitespace(json, ref index, ref line);

      if (index == json.Length) {
        return JSONToken.NONE;
      }

      char c = json[index];
      index++;
      switch (c) {
        case '{':
          return JSONToken.CURLY_OPEN;
        case '}':
          return JSONToken.CURLY_CLOSE;
        case '[':
          return JSONToken.SQUARED_OPEN;
        case ']':
          return JSONToken.SQUARED_CLOSE;
        case ',':
          return JSONToken.COMMA;
        case '"':
          return JSONToken.STRING;
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
        case '-':
          return JSONToken.NUMBER;
        case ':':
          return JSONToken.COLON;
      }
      index--;

      int remainingLength = json.Length - index;

      // false
      if (remainingLength >= 5) {
        if (json[index] == 'f' &&
            json[index + 1] == 'a' &&
            json[index + 2] == 'l' &&
            json[index + 3] == 's' &&
            json[index + 4] == 'e') {
          index += 5;
          return JSONToken.FALSE;
        }
      }

      // true
      if (remainingLength >= 4) {
        if (json[index] == 't' &&
            json[index + 1] == 'r' &&
            json[index + 2] == 'u' &&
            json[index + 3] == 'e') {
          index += 4;
          return JSONToken.TRUE;
        }
      }

      // null
      if (remainingLength >= 4) {
        if (json[index] == 'n' &&
            json[index + 1] == 'u' &&
            json[index + 2] == 'l' &&
            json[index + 3] == 'l') {
          index += 4;
          return JSONToken.NULL;
        }
      }

      return JSONToken.NONE;
    }

    internal static void SerializeValue(object value, StringBuilder builder)
    {
      if (value is string) {
        SerializeString((string)value, builder);
      } else if (value is Hashtable) {
        SerializeObject((Hashtable)value, builder);
      } else if (value is ArrayList) {
        SerializeArray((ArrayList)value, builder);
      } else if (IsNumeric(value)) {
        SerializeNumber(Convert.ToDouble(value), builder);
      } else if ((value is Boolean) && ((Boolean)value == true)) {
        builder.Append("true");
      } else if ((value is Boolean) && ((Boolean)value == false)) {
        builder.Append("false");
      } else if (value == null) {
        builder.Append("null");
      } else {
        throw new JsonException("Unsupported value type.");
      }
    }

    internal static bool SerializeObject(Hashtable anObject, StringBuilder builder)
    {
      builder.Append("{");

      IDictionaryEnumerator e = anObject.GetEnumerator();
      bool first = true;
      while (e.MoveNext()) {
        string key = e.Key.ToString();
        object value = e.Value;

        if (!first) {
          builder.Append(", ");
        }

        SerializeString(key, builder);
        builder.Append(":");
        SerializeValue(value, builder);

        first = false;
      }

      builder.Append("}");
      return true;
    }

    internal static bool SerializeArray(ArrayList anArray, StringBuilder builder)
    {
      builder.Append("[");

      bool first = true;
      for (int i = 0; i < anArray.Count; i++) {
        object value = anArray[i];

        if (!first) {
          builder.Append(", ");
        }

        SerializeValue(value, builder);

        first = false;
      }

      builder.Append("]");
      return true;
    }

    internal static bool SerializeString(string aString, StringBuilder builder)
    {
      builder.Append("\"");

      char[] charArray = aString.ToCharArray();
      for (int i = 0; i < charArray.Length; i++) {
        char c = charArray[i];
        if (c == '"') {
          builder.Append("\\\"");
        } else if (c == '\\') {
          builder.Append("\\\\");
        } else if (c == '\b') {
          builder.Append("\\b");
        } else if (c == '\f') {
          builder.Append("\\f");
        } else if (c == '\n') {
          builder.Append("\\n");
        } else if (c == '\r') {
          builder.Append("\\r");
        } else if (c == '\t') {
          builder.Append("\\t");
        } else {
          int codepoint = Convert.ToInt32(c);
          if ((codepoint >= 32) && (codepoint <= 126)) {
            builder.Append(c);
          } else {
            builder.Append("\\u" + Convert.ToString(codepoint, 16).PadLeft(4, '0'));
          }
        }
      }

      builder.Append("\"");
      return true;
    }

    internal static bool SerializeNumber(double number, StringBuilder builder)
    {
      builder.Append(Convert.ToString(number, CultureInfo.InvariantCulture));
      return true;
    }

    /// <summary>
    /// Determines if a given object is numeric in any way
    /// (can be integer, double, null, etc). 
    /// 
    /// Thanks to mtighe for pointing out Double.TryParse to me.
    /// </summary>
    protected static bool IsNumeric(object o)
    {
      double result;

      return (o == null) ? false : Double.TryParse(o.ToString(), out result);
    }
  }
}
