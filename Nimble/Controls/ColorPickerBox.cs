using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Nimble.Drawing;
using Nimble.Extensions;
using System.ComponentModel;

namespace Nimble.Controls
{
  public delegate void ColorPickerBoxClick(object sender, Color color);

  [DefaultEvent("Click")]
  public class ColorPickerBox : Control
  {
    private List<Color> _Colors = new List<Color>(new Color[] {
      // default color list based on Paint.Net collection
      // row 1
      Color.FromArgb(0, 0, 0),
      Color.FromArgb(64, 64, 64),
      Color.FromArgb(255, 0, 0),
      Color.FromArgb(255, 106, 0),
      Color.FromArgb(255, 216, 0),
      Color.FromArgb(182, 255, 0),
      Color.FromArgb(76, 255, 0),
      Color.FromArgb(0, 255, 33),
      Color.FromArgb(0, 255, 144),
      Color.FromArgb(0, 255, 255),
      Color.FromArgb(0, 148, 255),
      Color.FromArgb(0, 38, 255),
      Color.FromArgb(72, 0, 255),
      Color.FromArgb(178, 0, 255),
      Color.FromArgb(255, 0, 220),
      Color.FromArgb(255, 0, 110),
      // row 2
      Color.FromArgb(255, 255, 255),
      Color.FromArgb(128, 128, 128),
      Color.FromArgb(127, 0, 0),
      Color.FromArgb(127, 51, 0),
      Color.FromArgb(127, 106, 0),
      Color.FromArgb(91, 127, 0),
      Color.FromArgb(38, 127, 0),
      Color.FromArgb(0, 127, 14),
      Color.FromArgb(0, 127, 14),
      Color.FromArgb(0, 127, 127),
      Color.FromArgb(0, 74, 127),
      Color.FromArgb(0, 19, 127),
      Color.FromArgb(33, 0, 127),
      Color.FromArgb(87, 0, 127),
      Color.FromArgb(127, 0, 110),
      Color.FromArgb(127, 0, 55),
    });
    public List<Color> Colors
    {
      get { return _Colors; }
      set { _Colors = value; Invalidate(); }
    }

    private int _BoxSize = 12;
    public int BoxSize
    {
      get { return _BoxSize; }
      set { _BoxSize = value; Invalidate(); }
    }

    private Point _Mouse = new Point(-1, -1);
    private bool _MouseDown = false;
    private Color? _MouseColor = null;

    public new event ColorPickerBoxClick Click;

    protected override Size DefaultSize
    {
      get { return new Size(192, 48); }
    }

    public ColorPickerBox()
    {
      this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int x = 0, y = 0;
      bool bFoundHover = false;
      foreach (Color color in _Colors) {
        if (x + _BoxSize > this.Width) {
          x = 0;
          y += _BoxSize;
        }
        Rectangle rect = new Rectangle(x, y, _BoxSize, _BoxSize);
        using (SolidBrush brush = new SolidBrush(color)) {
          e.Graphics.FillRectangle(brush, rect);
        }
        if (rect.Contains(_Mouse)) {
          bFoundHover = true;
          if (!_MouseDown) {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, _BoxSize - 1, _BoxSize - 1));
            e.Graphics.DrawRectangle(Pens.White, new Rectangle(x + 1, y + 1, _BoxSize - 3, _BoxSize - 3));
            _MouseColor = color;
          }
        }
        x += _BoxSize;
      }
      if (!bFoundHover) {
        _MouseColor = null;
      }

      base.OnPaint(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.None) {
        _Mouse = e.Location;
        Invalidate();
      }
      base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      _Mouse = new Point(-1, -1);
      Invalidate();
      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      _MouseDown = true;
      Invalidate();
      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (_MouseColor.HasValue) {
        if (Click != null) {
          Click(this, _MouseColor.Value);
        }
      }
      _MouseDown = false;
      Invalidate();
      base.OnMouseUp(e);
    }
  }
}
