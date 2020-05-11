using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Nimble.Extensions
{
  public static class ImageExtensions
  {
    public static Image CloneImage(this Image img)
    {
      Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
      using (Graphics g = Graphics.FromImage(bmp)) {
        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
      }
      return bmp;
    }

    public static ImageFormat GetImageFormat(this Image img)
    {
      if (img.RawFormat.Equals(ImageFormat.Jpeg)) return ImageFormat.Jpeg;
      if (img.RawFormat.Equals(ImageFormat.Bmp)) return ImageFormat.Bmp;
      if (img.RawFormat.Equals(ImageFormat.Png)) return ImageFormat.Png;
      if (img.RawFormat.Equals(ImageFormat.Emf)) return ImageFormat.Emf;
      if (img.RawFormat.Equals(ImageFormat.Exif)) return ImageFormat.Exif;
      if (img.RawFormat.Equals(ImageFormat.Gif)) return ImageFormat.Gif;
      if (img.RawFormat.Equals(ImageFormat.Icon)) return ImageFormat.Icon;
      if (img.RawFormat.Equals(ImageFormat.MemoryBmp)) return ImageFormat.MemoryBmp;
      if (img.RawFormat.Equals(ImageFormat.Tiff)) return ImageFormat.Tiff;
      else return null;
    }

    public static string GetMime(this Image img)
    {
      if (img.RawFormat.Equals(ImageFormat.Jpeg)) return "image/jpeg";
      if (img.RawFormat.Equals(ImageFormat.Bmp)) return "image/bmp";
      if (img.RawFormat.Equals(ImageFormat.Png)) return "image/png";
      if (img.RawFormat.Equals(ImageFormat.Gif)) return "image/gif";
      if (img.RawFormat.Equals(ImageFormat.Icon)) return "image/x-icon";
      if (img.RawFormat.Equals(ImageFormat.MemoryBmp)) return "image/bmp";
      if (img.RawFormat.Equals(ImageFormat.Tiff)) return "image/tiff";
      return "image/unknown";
    }
  }
}
