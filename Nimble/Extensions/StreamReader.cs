using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nimble.Extensions
{
  public static class FileStreamExtensions
  {
    public static char ReadChar(this StreamReader fs)
    {
      return (char)fs.Read();
    }

    public static char PeekChar(this StreamReader fs)
    {
      return (char)fs.Peek();
    }

    public static void Seek(this StreamReader fs, int dir)
    {
      fs.BaseStream.Seek(dir, SeekOrigin.Current);
    }

    public static string ReadString(this StreamReader fs, int len)
    {
      char[] arr = new char[len];
      fs.Read(arr, 0, len);
      return new string(arr);
    }

    public static string ReadUntil(this StreamReader fs, params char[] c)
    {
      string ret = "";
      fs.ReadUntil(out ret, c);
      return ret;
    }

    public static char ReadUntil(this StreamReader fs, out string strOut, params char[] c)
    {
      var ret = new StringBuilder();
      char ccc = '\0';
      while (!fs.EndOfStream) {
        char cc = fs.ReadChar();
        if (c.Contains(cc)) {
          ccc = cc;
          break;
        }
        ret.Append(cc);
      }
      strOut = ret.ToString();
      return ccc;
    }

    public static bool Expect(this StreamReader fs, string str)
    {
      return fs.ReadString(str.Length) == str;
    }

    public static bool Expect(this StreamReader fs, char c)
    {
      return fs.ReadChar() == c;
    }
  }
}
