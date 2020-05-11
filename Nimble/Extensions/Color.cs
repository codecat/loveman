using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nimble.Drawing;
using System.Globalization;

namespace Nimble.Extensions
{
  public static class ColorExtensions
  {
    public static Color Lerp(this Color col, Color colOther, double fRatio)
    {
      return Color.FromArgb(
        (int)Math.Min(255, col.A + (colOther.A - col.A) * fRatio),
        (int)Math.Min(255, col.R + (colOther.R - col.R) * fRatio),
        (int)Math.Min(255, col.G + (colOther.G - col.G) * fRatio),
        (int)Math.Min(255, col.B + (colOther.B - col.B) * fRatio)
      );
    }

    public static string ToHexString(this Color col)
    {
      return
        col.R.ToString("X2") +
        col.G.ToString("X2") +
        col.B.ToString("X2");
    }

    private static string RepeatChar(char c, int x)
    {
      string ret = "";
      while (ret.Length < x) {
        ret += c;
      }
      return ret;
    }

    public static Color FromHexString(string str)
    {
      Color ret = Color.Black;
      if (str.Length > 1 && str[0] == '#') {
        str = str.Substring(1);
      }
      if(str.Length == 3) {
        try {
          int r = int.Parse(RepeatChar(str[0], 2), NumberStyles.HexNumber);
          int g = int.Parse(RepeatChar(str[1], 2), NumberStyles.HexNumber);
          int b = int.Parse(RepeatChar(str[2], 2), NumberStyles.HexNumber);
          ret = Color.FromArgb(r, g, b);
        } catch { }
      } else if(str.Length == 6) {
        try {
          int r = int.Parse(str.Substring(0, 2), NumberStyles.HexNumber);
          int g = int.Parse(str.Substring(2, 2), NumberStyles.HexNumber);
          int b = int.Parse(str.Substring(4, 2), NumberStyles.HexNumber);
          ret = Color.FromArgb(r, g, b);
        } catch { }
      }
      return ret;
    }

    public static Color ShiftHSL(this Color col, double fHue, double fSaturation, double fLightness)
    {
      ColorHSL hsl = new ColorHSL(col);
      hsl.Hue += fHue;
      hsl.Saturation += fSaturation;
      hsl.Lightness += fLightness;
      return hsl.ToColorRGB();
    }

    public static Color MultiplyHSL(this Color col, double fHue, double fSaturation, double fLightness)
    {
      ColorHSL hsl = new ColorHSL(col);
      hsl.Hue *= fHue;
      hsl.Saturation *= fSaturation;
      hsl.Lightness *= fLightness;
      return hsl.ToColorRGB();
    }

    public static Color ModHSL(this Color col, double fShiftHue, double fMultiplySaturation, double fMultiplyLightness)
    {
      ColorHSL hsl = new ColorHSL(col);
      hsl.Hue += fShiftHue;
      hsl.Saturation *= fMultiplySaturation;
      hsl.Lightness *= fMultiplyLightness;
      return hsl.ToColorRGB();
    }

    public static Color ShiftModHSL(this Color col, double fShiftHue, double fShiftSaturation, double fShiftLightness, double fMultiplySaturation, double fMultiplyLightness)
    {
      ColorHSL hsl = new ColorHSL(col);
      hsl.Hue += fShiftHue;
      hsl.Saturation += fShiftSaturation;
      hsl.Saturation *= fMultiplySaturation;
      hsl.Lightness += fShiftLightness;
      hsl.Lightness *= fMultiplyLightness;
      return hsl.ToColorRGB();
    }

    public static Color Inverted(this Color col)
    {
      return Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B);
    }
  }
}
