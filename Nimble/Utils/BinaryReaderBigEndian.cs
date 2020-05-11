using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nimble.Utils
{
  public class BinaryReaderBigEndian : BinaryReader
  {
    public BinaryReaderBigEndian(Stream stream) : base(stream) { }

    public int ReadInt32_BigEndian()
    {
      var bytes = base.ReadBytes(4);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }
      return BitConverter.ToInt32(bytes, 0);
    }

    public uint ReadUInt32_BigEndian()
    {
      var bytes = base.ReadBytes(4);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }
      return BitConverter.ToUInt32(bytes, 0);
    }

    public float ReadSingle_BigEndian()
    {
      var bytes = base.ReadBytes(4);
      if (BitConverter.IsLittleEndian) {
        Array.Reverse(bytes);
      }
      return BitConverter.ToSingle(bytes, 0);
    }
  }
}
