using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Nimble.Drawing
{
  // Based on: http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
  public class ColorHSL
  {
    public double Hue = 0;
    public double Saturation = 0;
    public double Lightness = 0;

    public ColorHSL() { }
    public ColorHSL(double h, double s, double l)
    {
      Hue = h;
      Saturation = s;
      Lightness = l;
    }
    public ColorHSL(Color rgb)
    {
      double r = rgb.R / 255.0;
      double g = rgb.G / 255.0;
      double b = rgb.B / 255.0;
      double v;
      double m;
      double vm;
      double r2, g2, b2;

      v = Math.Max(r, g);
      v = Math.Max(v, b);
      m = Math.Min(r, g);
      m = Math.Min(m, b);
      Lightness = (m + v) / 2.0;
      if (Lightness <= 0.0) {
        return;
      }

      vm = v - m;
      Saturation = vm;
      if (Saturation > 0.0) {
        Saturation /= (Lightness <= 0.5) ? (v + m) : (2.0 - v - m);
      } else {
        return;
      }

      r2 = (v - r) / vm;
      g2 = (v - g) / vm;
      b2 = (v - b) / vm;

      if (r == v) {
        Hue = (g == m ? 5.0 + b2 : 1.0 - g2);
      } else if (g == v) {
        Hue = (b == m ? 1.0 + r2 : 3.0 - b2);
      } else {
        Hue = (r == m ? 3.0 + g2 : 5.0 - r2);
      }

      Hue /= 6.0;
    }

    public Color ToColorRGB()
    {
      double v;
      double r, g, b;

      double h = Hue;
      double sl = Saturation;
      double l = Lightness;

      r = l; // default to grey
      g = l;
      b = l;
      v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

      if (v > 0) {
        double m;
        double sv;
        int sextant;
        double fract, vsf, mid1, mid2;

        m = l + l - v;
        sv = (v - m) / v;
        h *= 5.0;
        sextant = (int)h;
        fract = h - sextant;
        vsf = v * sv * fract;
        mid1 = m + vsf;
        mid2 = v - vsf;

        switch (sextant) {
          case 0: r = v; g = mid1; b = m; break;
          case 1: r = mid2; g = v; b = m; break;
          case 2: r = m; g = v; b = mid1; break;
          case 3: r = m; g = mid2; b = v; break;
          case 4: r = mid1; g = m; b = v; break;
          case 5: r = v; g = m; b = mid2; break;
        }
      }

      return Color.FromArgb(
        Convert.ToByte(Math.Min(1.0f, r) * 255.0f),
        Convert.ToByte(Math.Min(1.0f, g) * 255.0f),
        Convert.ToByte(Math.Min(1.0f, b) * 255.0f));
    }

    public static double HueForColor(Color col)
    {
      return new ColorHSL(col).Hue;
    }

    public static Color Modify(ColorHSL col, double h, double s, double l)
    {
      ColorHSL hsl = new ColorHSL();
      hsl.Hue = col.Hue * h;
      hsl.Saturation = col.Saturation * s;
      hsl.Lightness = col.Lightness * l;
      return hsl.ToColorRGB();
    }

    public static Color Modify(Color col, double h, double s, double l)
    {
      ColorHSL hsl = new ColorHSL(col);
      hsl.Hue *= h;
      hsl.Saturation *= s;
      hsl.Lightness *= l;
      return hsl.ToColorRGB();
    }

    public static Color ModifyLightness(ColorHSL col, double delta, bool lighten)
    {
      ColorHSL hsl = new ColorHSL();
      hsl.Hue = col.Hue;
      hsl.Saturation = col.Saturation;
      if (lighten) {
        hsl.Lightness = col.Lightness * (1.0 + delta);
      } else {
        hsl.Lightness = col.Lightness * (1.0 - delta);
      }
      return hsl.ToColorRGB();
    }

    public static Color ModifyLightness(Color col, double delta, bool lighten)
    {
      ColorHSL hsl = new ColorHSL(col);
      if (lighten) {
        hsl.Lightness = Math.Max(0.2, hsl.Lightness) * (1.0 + delta);
      } else {
        hsl.Lightness *= 1.0 - delta;
      }
      return hsl.ToColorRGB();
    }
  }
}
