using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nimble.JSON
{
  public class JsonException : Exception
  {
    private string _message;
    private int _index;
    private int _line;

    public JsonException(string strMessage)
    {
      _message = strMessage;
      _index = 0;
    }

    public JsonException(string strMessage, int iIndex, int iLine)
    {
      _message = strMessage;
      _index = iIndex;
      _line = iLine;
    }

    public override string Message { get { return _message; } }
    public int Index { get { return _index; } }
    public int Line { get { return _line; } }
  }
}
