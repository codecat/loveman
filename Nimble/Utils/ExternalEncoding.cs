using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nimble.Utils
{
  public static class ExternalEncoding
  {
    public static string EncodeHtml(string str)
    {
      return str
        .Replace("&", "&amp;")
        .Replace("<", "&lt;")
        .Replace(">", "&gt;")
        .Replace("\"", "&quot;")
        .Replace("'", "&apos;");
    }

    /// <summary>
    /// Encode a string in base64
    /// </summary>
    /// <param name="input">The string to be encoded</param>
    /// <returns>The encoded base64 string</returns>
    public static string Base64Encode(string input)
    {
      return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
    }

    public static string Base64Encode(byte[] input)
    {
      return Convert.ToBase64String(input);
    }

    public static string Base64Encode(MemoryStream ms)
    {
      return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// Decode a base64 string
    /// </summary>
    /// <param name="input">The base64 string to be decoded</param>
    /// <returns>The decoded string</returns>
    public static string Base64Decode(string input)
    {
      return Encoding.ASCII.GetString(Convert.FromBase64String(input));
    }

    /// <summary>
    /// Alternative of <see cref="M:System.Uri.EscapeDataString(System.String)"/> to allow for much longer data to be escaped
    /// </summary>
    /// <param name="Str">The string to be escaped</param>
    /// <returns>The escaped string</returns>
    public static string LongDataEscape(string Str)
    {
      string Output = "";
      int ByteCount = 32766;
      if (Str.Length > ByteCount) {
        for (int i = 0; i < Str.Length; i += ByteCount) {
          if (Str.Length - i < ByteCount)
            Output += Uri.EscapeDataString(Str.Substring(i, Str.Length - i));
          else
            Output += Uri.EscapeDataString(Str.Substring(i, ByteCount));
        }
      } else
        Output = Uri.EscapeDataString(Str);
      return Output;
    }
  }
}
