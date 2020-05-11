using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Nimble.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Nimble.Controls
{
  // Algorithm for drawing the color wheel borrowed from the wonderful Paint.Net
  [DefaultEvent("OnColorChanged")]
  public class ColorWheel : Control
  {
    private Bitmap _bmpColorWheel = null;

    private double _HueDegrees = 180;
    public double HueDegrees
    {
      get { return _HueDegrees; }
      set { _HueDegrees = value; Invalidate(); }
    }

    private double _SaturationPercent = 100;
    public double SaturationPercent
    {
      get { return _SaturationPercent; }
      set { _SaturationPercent = value; Invalidate(); }
    }

    private int _wheelRadius = 0;
    private int _wheelCenter = 0;

    public event EventHandler OnColorChanged;

    public ColorHSV Color
    {
      get { return new ColorHSV(_HueDegrees, _SaturationPercent, 100); }
      set
      {
        _HueDegrees = value.Hue;
        _SaturationPercent = value.Saturation;
        Invalidate();
      }
    }

    protected override Size DefaultSize
    {
      get { return new Size(141, 141); }
    }

    public ColorWheel()
    {
      this.DoubleBuffered = true;
    }

    protected override void OnResize(EventArgs e)
    {
      this.Height = this.Width;
      if (_bmpColorWheel != null) {
        _bmpColorWheel.Dispose();
        _bmpColorWheel = null;
      }
      base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (_bmpColorWheel == null) {
        _bmpColorWheel = new Bitmap(this.Width, this.Height);

        BitmapData bmpData = _bmpColorWheel.LockBits(new Rectangle(0, 0, this.Width, this.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        byte[] buffer = new byte[Math.Abs(bmpData.Stride) * _bmpColorWheel.Height];

        _wheelCenter = _bmpColorWheel.Width / 2;
        _wheelRadius = _wheelCenter % 2 == 0 ? _wheelCenter - 1 : _wheelCenter;

        for (int y = 0; y < _bmpColorWheel.Height; y++) {
          int yb = y * _bmpColorWheel.Width * 4;
          for (int x = 0; x < _bmpColorWheel.Width; x++) {
            double dx = (double)(x - _wheelCenter);
            double dy = (double)(y - _wheelCenter);
            byte r = 0, g = 0, b = 0, a = 0;
            GetColor(_wheelRadius, dx, dy, ref r, ref g, ref b, ref a);
            buffer[yb + x * 4 + 3] = a;
            buffer[yb + x * 4 + 2] = r;
            buffer[yb + x * 4 + 1] = g;
            buffer[yb + x * 4 + 0] = b;
          }
        }

        System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);
        _bmpColorWheel.UnlockBits(bmpData);
      }

      e.Graphics.DrawImage(_bmpColorWheel, new Rectangle(0, 0, _bmpColorWheel.Width, _bmpColorWheel.Height));
      double nubTheta = _HueDegrees * 0.017453292519943295;
      double nubRadius = Math.Pow(_SaturationPercent * 0.01, 0.7142857142857143);
      DrawNub(e.Graphics, nubTheta, nubRadius);

      base.OnPaint(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
        GrabColor(e.Location);
      }
      base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
        GrabColor(e.Location);
      }
      base.OnMouseMove(e);
    }

    private void DrawNub(Graphics g, double theta, double radius)
    {
      int nubRadius = 5;
      int nubDiameter = nubRadius * 2;
      double x = this.Width / 2.0 - nubRadius + radius * _wheelRadius * Math.Cos(theta);
      double y = this.Height / 2.0 - nubRadius + radius * _wheelRadius * Math.Sin(theta);
      g.SmoothingMode = SmoothingMode.HighQuality;
      using (SolidBrush brush = new SolidBrush(new ColorHSV(_HueDegrees, _SaturationPercent, 100).ToColorRGB())) {
        g.FillEllipse(brush, (int)x, (int)y, nubDiameter, nubDiameter);
      }
      g.DrawEllipse(Pens.Black, (int)x, (int)y, nubDiameter, nubDiameter);
      g.DrawEllipse(Pens.White, (int)x + 1, (int)y + 1, nubDiameter - 2, nubDiameter - 2);
    }

    private void GrabColor(Point pt)
    {
      double dx = pt.X - _wheelCenter;
      double dy = pt.Y - _wheelCenter;
      double thetaColor = Math.Atan2(dy, dx);
      if (thetaColor < 0) {
        thetaColor += Math.PI * 2;
      }
      double alpha = Math.Sqrt(dx * dx + dy * dy);
      double h = thetaColor * 57.295779513082323;
      double s = Math.Pow(Math.Min(1.0, alpha / (double)_wheelRadius), 1.4);
      _HueDegrees = (int)(0.5 + h);
      _SaturationPercent = (int)(0.5 + 100.0 * s);
      Invalidate();
      if (OnColorChanged != null) {
        OnColorChanged(this, new EventArgs());
      }
    }

    private void GetColor(int radiusTarget, double dx, double dy, ref byte r, ref byte g, ref byte b, ref byte a)
    {
      double radius = Math.Sqrt(dx * dx + dy * dy);
      double angle = (dx == 0 && dy == 0) ? 0 : Math.Atan2(dy, dx);
      if (angle < 0) {
        angle += Math.PI * 2;
      }
      double hue = angle * 3.0 / Math.PI;
      if (radius <= radiusTarget) {
        double saturation = Math.Pow(radius / radiusTarget, 1.4);
        FromHSA(hue, saturation, 1, ref r, ref g, ref b, ref a);
      } else {
        double distance = radius - radiusTarget;
        if (radius - radiusTarget < 1) {
          FromHSA(hue, 1, 1.0 - distance - (int)distance, ref r, ref g, ref b, ref a);
        }
      }
    }

    private void FromHSA(double h, double s, double a, ref byte or, ref byte og, ref byte ob, ref byte oa)
    {
      if (s == 0) {
        or = og = ob = oa = 255;
        return;
      }
      double r = 0, g = 0, b = 0;
      int sector = (int)h;
      double fractional = h - sector;
      double p = 255.0 * (1.0 - s);
      double q = 255.0 * (1.0 - s * fractional);
      double t = 255.0 * (1.0 - s * (1.0 - fractional));
      switch (sector) {
        case 0: r = 255; g = t; b = p; break;
        case 1: r = q; g = 255; b = p; break;
        case 2: r = p; g = 255; b = t; break;
        case 3: r = p; g = q; b = 255; break;
        case 4: r = t; g = p; b = 255; break;
        case 5: r = 255; g = p; b = q; break;
      }
      or = (byte)(r + 0.5);
      og = (byte)(g + 0.5);
      ob = (byte)(b + 0.5);
      oa = (byte)(a * 255.0 + 0.5);
    }
  }
}
