using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Nimble.Drawing
{
  public class ColorHSV
  {
    private double _Hue = 0;
    private double _Saturation = 0;
    private double _Value = 0;

    public double Hue
    {
      get { return _Hue; }
      set { _Hue = value % 360.0; }
    }
    public double Saturation
    {
      get { return _Saturation; }
      set { _Saturation = Math.Min(100, Math.Max(0, value)); }
    }
    public double Value
    {
      get { return _Value; }
      set { _Value = Math.Min(100, Math.Max(0, value)); }
    }

    public ColorHSV() { }

    public ColorHSV(double h, double s, double v)
    {
      Hue = h;
      Saturation = s;
      Value = v;
    }

    public ColorHSV(Color rgb)
    {
      double r = rgb.R / 255.0;
      double g = rgb.G / 255.0;
      double b = rgb.B / 255.0;
      double min = Math.Min(Math.Min(r, g), b);
      double max = Math.Max(Math.Max(r, g), b);
      double delta = max - min;
      if (max != 0 && delta != 0) {
        Saturation = (delta / max) * 100.0;
        if (r == max) {
          Hue = (g - b) / delta;
        } else {
          Hue = (g == max) ? (2 + (b - r) / delta) : (4 + (r - g) / delta);
        }
      }
      Hue *= 60;
      if (Hue < 0) {
        Hue += 360;
      }
      Value = max * 100.0;
    }

    public Color ToColorRGB()
    {
      double r = 0, g = 0, b = 0;
      double h = Hue % 360.0;
      double s = Saturation / 100.0;
      double v = Value / 100.0;
      if (s == 0) {
        r = g = b = v;
      } else {
        double sPos = h / 60.0;
        int sNum = (int)Math.Floor(sPos);
        double fractional = sPos - (double)sNum;
        double p = v * (1.0 - s);
        double q = v * (1.0 - s * fractional);
        double t = v * (1.0 - s * (1.0 - fractional));
        switch (sNum) {
          case 0: r = v; g = t; b = p; break;
          case 1: r = q; g = v; b = p; break;
          case 2: r = p; g = v; b = t; break;
          case 3: r = p; g = q; b = v; break;
          case 4: r = t; g = p; b = v; break;
          case 5: r = v; g = p; b = q; break;
        }
      }
      return Color.FromArgb((byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
    }

    public static Color Modify(ColorHSV col, double h, double s, double l)
    {
      ColorHSV hsv = new ColorHSV();
      hsv.Hue = col.Hue * h;
      hsv.Saturation = col.Saturation * s;
      hsv.Value = col.Value * l;
      return hsv.ToColorRGB();
    }

    public static Color Modify(Color col, double h, double s, double l)
    {
      ColorHSV hsv = new ColorHSV(col);
      hsv.Hue *= h;
      hsv.Saturation *= s;
      hsv.Value *= l;
      return hsv.ToColorRGB();
    }

    public static Color ModifyValue(ColorHSV col, double delta, bool lighten)
    {
      ColorHSV hsv = new ColorHSV();
      hsv.Hue = col.Hue;
      hsv.Saturation = col.Saturation;
      if (lighten) {
        hsv.Value = col.Value * (1.0 + delta);
      } else {
        hsv.Value = col.Value * (1.0 - delta);
      }
      return hsv.ToColorRGB();
    }

    public static Color ModifyValue(Color col, double delta, bool lighten)
    {
      ColorHSV hsv = new ColorHSV(col);
      if (lighten) {
        hsv.Value = Math.Max(20, hsv.Value) * (1.0 + delta);
      } else {
        hsv.Value *= 1.0 - delta;
      }
      return hsv.ToColorRGB();
    }
  }
}
