using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimble.Utils;

namespace Nimble.Icns
{
  /// <summary>
  /// Icon type
  /// </summary>
  public enum IcnsType
  {
    unsupported,

    // Non-retina
    icp4_16x16,
    icp5_32x32,
    icp6_64x64,
    ic07_128x128,
    ic08_256x256,
    ic09_512x512,
    ic10_1024x1024,

    // Retina
    ic11_16x16x2,
    ic12_32x32x2,
    ic13_128x128x2,
    ic14_256x256x2,
  }

  public class IcnsIcon
  {
    public Image Image { get; set; }
    public IcnsType Type { get; set; }

    internal int FileSize { get; set; }

    private MemoryStream m_saveBuffer;

    private IcnsIcon()
    {
    }

    public IcnsIcon(Image image, IcnsType type)
      : this()
    {
      Image = image;
      Type = type;
    }

    internal IcnsIcon(IcnsType type, int fileSize)
      : this()
    {
      Type = type;
      FileSize = fileSize;
    }

    internal void Read(BinaryReaderBigEndian reader)
    {
      var buffer = reader.ReadBytes(FileSize);
      using (var ms = new MemoryStream(buffer)) {
        Image = Image.FromStream(ms);
      }

#if DEBUG
      var expectedSize = IcnsFile.GetSizeForType(Type);
      if (Image.Size != expectedSize) {
        Console.WriteLine("WARNING: Expected size {0}, got {1} for type {2}", expectedSize, Image.Size, Type);
      }
#endif
    }

    internal MemoryStream GetSaveBuffer()
    {
      if (m_saveBuffer == null) {
        m_saveBuffer = new MemoryStream();
        Image.Save(m_saveBuffer, ImageFormat.Png);
      }

      m_saveBuffer.Seek(0, SeekOrigin.Begin);
      return m_saveBuffer;
    }
  }

  public class IcnsFile
  {
    public List<IcnsIcon> Icons { get; set; }

    public IcnsFile()
    {
      Icons = new List<IcnsIcon>();
    }

    public IcnsFile(string filename)
      : this()
    {
      using (var fs = File.OpenRead(filename)) {
        using (var reader = new BinaryReaderBigEndian(fs)) {
          var magic = Encoding.ASCII.GetString(reader.ReadBytes(4));
          if (magic != "icns") {
            throw new FileLoadException("File is not an icns file.", filename);
          }

          uint fileSize = reader.ReadUInt32_BigEndian();

          while (fs.Position < fs.Length) {
            var osType = Encoding.ASCII.GetString(reader.ReadBytes(4));
            var osSize = reader.ReadInt32_BigEndian() - 8;

            if (osType == "TOC ") {
#if DEBUG
              Console.WriteLine("There are {0} icons in the table of contents", osSize / 8);
#endif
              fs.Seek(osSize, SeekOrigin.Current);
              continue;
            }

            if (osType == "icnV") {
              float version = reader.ReadSingle_BigEndian();
#if DEBUG
              Console.WriteLine("This icon was made with Icon Composer.app version {0}", version);
#endif
              continue;
            }

            if (osType == "name") {
#if DEBUG
              Console.WriteLine("Encountered a 'name' OSType with size {0}", osSize);
#endif
              fs.Seek(osSize, SeekOrigin.Current);
              continue;
            }

            if (osType == "info") {
#if DEBUG
              Console.WriteLine("Encountered an 'info' binary plist OSType with size {0}", osSize);
#endif
              fs.Seek(osSize, SeekOrigin.Current);
              continue;
            }

            IcnsType iconType;
            try {
              iconType = GetTypeForIdent(osType);
            } catch {
              fs.Seek(osSize, SeekOrigin.Current);
#if DEBUG
              Console.WriteLine("WARNING: Unsupported OSType: '{0}' with size {1}", osType, osSize);
#endif
              Icons.Add(new IcnsIcon(IcnsType.unsupported, osSize));
              continue;
            }

#if DEBUG
            var iconSize = GetSizeForType(iconType);
            Console.WriteLine("Icon size: {0} x {1}", iconSize.Width, iconSize.Height);
#endif
            var newIcon = new IcnsIcon(iconType, osSize);
            newIcon.Read(reader);
            Icons.Add(newIcon);
          }
        }
      }
    }

    public IcnsIcon AddImage(Image image, IcnsType type)
    {
      var ret = new IcnsIcon(image, type);
      Icons.Add(ret);
      return ret;
    }

    public IcnsIcon AddImage(string filename, IcnsType type)
    {
      using (var image = Image.FromFile(filename)) {
        var newImage = (Image)image.Clone();
        var ret = new IcnsIcon(newImage, type);
        Icons.Add(ret);
        return ret;
      }
    }

    public void Save(string filename)
    {
      if (File.Exists(filename)) {
        File.Delete(filename);
      }

      uint fileSize = 8; // 'icns' + fileSize
      uint tocSize = 8; // TOC header
      foreach (var icon in Icons) {
        if (icon.Type == IcnsType.unsupported) {
          continue;
        }

        var saveBuffer = icon.GetSaveBuffer();
        fileSize += (uint)saveBuffer.Length + 8; // OSType + data size + savebuffer
        tocSize += 8; // TOC entry
      }
      fileSize += tocSize;

      using (var fs = File.Create(filename)) {
        using (var writer = new BinaryWriterBigEndian(fs)) {
          writer.Write(Encoding.ASCII.GetBytes("icns"));
          writer.WriteBigEndian(fileSize);

          writer.Write(Encoding.ASCII.GetBytes("TOC "));
          writer.WriteBigEndian(tocSize);

          foreach (var icon in Icons) {
            if (icon.Type == IcnsType.unsupported) {
              continue;
            }

            var saveBuffer = icon.GetSaveBuffer();
            writer.Write(Encoding.ASCII.GetBytes(GetIdentForType(icon.Type)));
            writer.WriteBigEndian((uint)saveBuffer.Length);
          }

          foreach (var icon in Icons) {
            if (icon.Type == IcnsType.unsupported) {
              continue;
            }

            var saveBuffer = icon.GetSaveBuffer();
            writer.Write(Encoding.ASCII.GetBytes(GetIdentForType(icon.Type)));
            writer.WriteBigEndian((uint)saveBuffer.Length + 8);
            writer.Write(saveBuffer.ToArray());
          }
        }
      }
    }

    public static Size GetSizeForType(IcnsType type)
    {
      switch (type) {
        case IcnsType.icp4_16x16: return new Size(16, 16);
        case IcnsType.icp5_32x32: return new Size(32, 32);
        case IcnsType.icp6_64x64: return new Size(64, 64);
        case IcnsType.ic07_128x128: return new Size(128, 128);
        case IcnsType.ic08_256x256: return new Size(256, 256);
        case IcnsType.ic09_512x512: return new Size(512, 512);
        case IcnsType.ic10_1024x1024: return new Size(1024, 1024);

        case IcnsType.ic11_16x16x2: return new Size(32, 32);
        case IcnsType.ic12_32x32x2: return new Size(64, 64);
        case IcnsType.ic13_128x128x2: return new Size(256, 256);
        case IcnsType.ic14_256x256x2: return new Size(512, 512);
      }

      throw new ArgumentException("Invalid icons type!", "type");
    }

    public static IcnsType GetTypeForIdent(string ident)
    {
      switch (ident) {
        case "icp4": return IcnsType.icp4_16x16;
        case "icp5": return IcnsType.icp5_32x32;
        case "icp6": return IcnsType.icp6_64x64;
        case "ic07": return IcnsType.ic07_128x128;
        case "ic08": return IcnsType.ic08_256x256;
        case "ic09": return IcnsType.ic09_512x512;
        case "ic10": return IcnsType.ic10_1024x1024;

        case "ic11": return IcnsType.ic11_16x16x2;
        case "ic12": return IcnsType.ic12_32x32x2;
        case "ic13": return IcnsType.ic13_128x128x2;
        case "ic14": return IcnsType.ic14_256x256x2;
      }

      throw new ArgumentException("Unsupported OSType '" + ident + "'!", "ident");
    }

    public static string GetIdentForType(IcnsType type)
    {
      switch (type) {
        case IcnsType.icp4_16x16: return "icp4";
        case IcnsType.icp5_32x32: return "icp5";
        case IcnsType.icp6_64x64: return "icp6";
        case IcnsType.ic07_128x128: return "ic07";
        case IcnsType.ic08_256x256: return "ic08";
        case IcnsType.ic09_512x512: return "ic09";
        case IcnsType.ic10_1024x1024: return "ic10";

        case IcnsType.ic11_16x16x2: return "ic11";
        case IcnsType.ic12_32x32x2: return "ic12";
        case IcnsType.ic13_128x128x2: return "ic13";
        case IcnsType.ic14_256x256x2: return "ic14";
      }

      throw new ArgumentException("Invalid icons type!", "type");
    }
  }
}
