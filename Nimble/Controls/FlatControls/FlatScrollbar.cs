using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nimble.Controls.FlatControls
{
  [DefaultEvent("ValueChanged")]
  public partial class FlatScrollbar : UserControl
  {
    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _FillColor = Color.Gray;
    [Description("Color of the fill value")]
    [Category("Appearance")]
    public Color FillColor
    {
      get { return _FillColor; }
      set { _FillColor = value; Invalidate(); }
    }

    private bool _ShowHandle = true;
    [Description("Show the handle")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool HandleVisible
    {
      get { return _ShowHandle; }
      set { _ShowHandle = value; Invalidate(); }
    }

    private int _HandleWidth = 2;
    [Description("Width of the handle")]
    [Category("Appearance")]
    [DefaultValue(2)]
    public int HandleWidth
    {
      get { return _HandleWidth; }
      set { _HandleWidth = value; Invalidate(); }
    }

    private double _HandleMargin = 0.15;
    [Description("Margin of the handle")]
    [Category("Appearance")]
    [DefaultValue(0.15)]
    public double HandleMargin
    {
      get { return _HandleMargin; }
      set { _HandleMargin = value; Invalidate(); }
    }

    private Color _HandleColor = Color.Silver;
    [Description("Color of the handle")]
    [Category("Appearance")]
    public Color HandleColor
    {
      get { return _HandleColor; }
      set { _HandleColor = value; Invalidate(); }
    }

    private bool _ShowHandleGrip = true;
    [Description("Show the handle grip")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool HandleGripVisible
    {
      get { return _ShowHandleGrip; }
      set { _ShowHandleGrip = value; Invalidate(); }
    }

    private Color _HandleGripColor = Color.Black;
    [Description("Color of the handle grip")]
    [Category("Appearance")]
    public Color HandleGripColor
    {
      get { return _HandleGripColor; }
      set { _HandleGripColor = value; Invalidate(); }
    }

    private int _HandleGripCount = 1;
    [Description("Amount of visible grips on the handle")]
    [Category("Appearance")]
    [DefaultValue(1)]
    public int HandleGripCount
    {
      get { return _HandleGripCount; }
      set { _HandleGripCount = value; Invalidate(); }
    }

    private int _HandleGripOffset = 0;
    [Description("Grip offset")]
    [Category("Appearance")]
    [DefaultValue(0)]
    public int HandleGripOffset
    {
      get { return _HandleGripOffset; }
      set { _HandleGripOffset = value; Invalidate(); }
    }

    private int _HandleGripSize = 1;
    [Description("Grip size")]
    [Category("Appearance")]
    [DefaultValue(1)]
    public int HandleGripSize
    {
      get { return _HandleGripSize; }
      set { _HandleGripSize = value; Invalidate(); }
    }

    private double _HandleGripMargin = 0.0;
    [Description("Grip margin")]
    [Category("Appearance")]
    [DefaultValue(0.0)]
    public double HandleGripMargin
    {
      get { return _HandleGripMargin; }
      set { _HandleGripMargin = value; Invalidate(); }
    }

    private bool _ShowGuidelines = false;
    [Description("Show step guidelines")]
    [Category("Appearance")]
    [DefaultValue(false)]
    public bool GuidelinesVisible
    {
      get { return _ShowGuidelines; }
      set { _ShowGuidelines = value; Invalidate(); }
    }

    private Color _GuidelineColor = Color.White;
    [Description("Color of the guidelines")]
    [Category("Appearance")]
    public Color GuidelineColor
    {
      get { return _GuidelineColor; }
      set { _GuidelineColor = value; Invalidate(); }
    }

    private int _GuidelineWidth = 1;
    [Description("Width of a guideline")]
    [Category("Appearance")]
    [DefaultValue(1)]
    public int GuidelineWidth
    {
      get { return _GuidelineWidth; }
      set { _GuidelineWidth = value; Invalidate(); }
    }

    private int _GuidelineHeight = 6;
    [Description("Height of a guideline")]
    [Category("Appearance")]
    [DefaultValue(6)]
    public int GuidelineHeight
    {
      get { return _GuidelineHeight; }
      set { _GuidelineHeight = value; Invalidate(); }
    }

    private bool _ClickRangeUsed = false;
    [Description("Use click range")]
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool ClickRangeUsed
    {
      get { return _ClickRangeUsed; }
      set { _ClickRangeUsed = value; }
    }

    private int _ClickRange = 20;
    [Description("Click range, distance from handle center in pixels")]
    [Category("Behavior")]
    [DefaultValue(20)]
    public int ClickRange
    {
      get { return _ClickRange; }
      set { _ClickRange = value; }
    }

    private Cursor _ClickRangeCursor = Cursors.VSplit;
    [Description("Cursor used when cursor is in click range")]
    [Category("Behavior")]
    public Cursor ClickRangeCursor
    {
      get { return _ClickRangeCursor; }
      set { _ClickRangeCursor = value; }
    }

    private int _Value = 50;
    [Description("Value of the scrollbar")]
    [Category("Scrollbar")]
    public int Value
    {
      get { return _Value; }
      set
      {
        if (value != _Value) {
          _Value = value;
          Invalidate();
          Update();
          if (ValueChanged != null) {
            ValueChanged(this, new EventArgs());
          }
        }
      }
    }

    private int _Minimum = 0;
    [Description("Minimum value of the scrollbar")]
    [Category("Scrollbar")]
    public int Minimum
    {
      get { return _Minimum; }
      set { _Minimum = value; Invalidate(); }
    }

    private int _Maximum = 100;
    [Description("Maximum value of the scrollbar")]
    [Category("Scrollbar")]
    public int Maximum
    {
      get { return _Maximum; }
      set { _Maximum = value; Invalidate(); }
    }

    [Description("Called when the value changes")]
    [Category("Scrollbar")]
    public event EventHandler ValueChanged;

    private bool _bCanDrag = false;

    public FlatScrollbar()
    {
      InitializeComponent();
    }

    public double GetRatio()
    {
      return (double)(_Value - _Minimum) / (double)(_Maximum - _Minimum);
    }

    public Rectangle GetFillRectangle()
    {
      Rectangle ret = new Rectangle();

      ret.X = 0;
      ret.Y = 0;
      ret.Width = (int)(Size.Width * GetRatio());
      ret.Height = Size.Height;

      return ret;
    }

    public Rectangle GetHandleRectangle()
    {
      Rectangle ret = new Rectangle();

      Rectangle fill = GetFillRectangle();

      ret.X = fill.Width - _HandleWidth / 2;
      ret.Y = (int)(fill.Height * _HandleMargin);
      ret.Width = _HandleWidth;
      ret.Height = (int)(fill.Height * (1.0 - _HandleMargin * 2));

      return ret;
    }

    private void FlatScrollbar_Paint(object sender, PaintEventArgs e)
    {
      using (SolidBrush brush = new SolidBrush(_FillColor)) {
        e.Graphics.FillRectangle(brush, GetFillRectangle());
      }

      if (_ShowHandle) {
        Rectangle handle = GetHandleRectangle();
        using (SolidBrush brush = new SolidBrush(_HandleColor)) {
          e.Graphics.FillRectangle(brush, handle);
        }
        if (_ShowHandleGrip) {
          using (SolidBrush brushGrip = new SolidBrush(_HandleGripColor)) {
            for (int i = 0; i < _HandleGripCount; i++) {
              e.Graphics.FillRectangle(brushGrip, new Rectangle(
                handle.X + (int)Math.Floor((handle.Width / (double)_HandleGripCount) * (i + 0.5)) - (int)Math.Floor(_HandleGripSize / 2.0),
                handle.Y + _HandleGripOffset,
                _HandleGripSize,
                (int)Math.Floor(handle.Height * (1.0 - _HandleGripMargin * 2))
              ));
            }
          }
        }
      }

      if (_ShowGuidelines) {
        double step = Size.Width / (double)(_Maximum - _Minimum);
        using (SolidBrush brushGuideline = new SolidBrush(_GuidelineColor)) {
          for (int i = 0; i < (_Maximum - _Minimum); i++) {
            e.Graphics.FillRectangle(brushGuideline, new Rectangle(
              (int)Math.Round(i * step - _GuidelineWidth / 2.0), 0,
              _GuidelineWidth, _GuidelineHeight
            ));
          }
        }
      }

      using (Pen pen = new Pen(_BorderColor)) {
        e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Size.Width - 1, Size.Height - 1));
      }
    }

    private void FlatScrollbar_Resize(object sender, EventArgs e)
    {
      if (DesignMode) {
        RecreateHandle();
      } else {
        Invalidate();
      }
    }

    public bool InClickRange(Point location)
    {
      Rectangle handle = GetHandleRectangle();
      int iMiddleX = handle.X + handle.Width / 2;
      int iDelta = Math.Abs(location.X - iMiddleX);
      return iDelta < _ClickRange;
    }

    private void FlatScrollbar_MouseMove(object sender, MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (e.Button == MouseButtons.Left && _bCanDrag) {
        int iNewValue = _Minimum + (int)Math.Round((e.Location.X / (double)Size.Width) * (_Maximum - _Minimum));
        Value = Math.Max(_Minimum, Math.Min(_Maximum, iNewValue));
      }

      if (_ClickRangeUsed && InClickRange(e.Location)) {
        Cursor = _ClickRangeCursor;
      } else {
        Cursor = Cursors.Default;
      }
    }

    private void FlatScrollbar_MouseDown(object sender, MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (_ClickRangeUsed) {
        _bCanDrag = InClickRange(e.Location);
      } else {
        _bCanDrag = true;
      }

      FlatScrollbar_MouseMove(sender, e);
    }
  }
}
