using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nimble.Utils
{
  public class BinaryWriterBigEndian : BinaryWriter
  {
    public BinaryWriterBigEndian(Stream stream) : base(stream) { }

    public void WriteBigEndian(int value)
    {
      var bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }
      Write(bytes);
    }

    public void WriteBigEndian(uint value)
    {
      var bytes = BitConverter.GetBytes(value);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }
      Write(bytes);
    }
  }
}
