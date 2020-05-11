using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Nimble.Controls.FlatControls
{
  public partial class FlatArrowContainer : UserControl
  {
    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private bool _AutoDisappear = true;
    [Description("Automatically disappear when mouse leaves container")]
    [Category("Behavior")]
    public bool AutoDisappear
    {
      get { return _AutoDisappear; }
      set { _AutoDisappear = value; }
    }

    private int _ArrowWidth = 20;
    [Description("Width of the arrow")]
    [Category("Appearance")]
    public int ArrowWidth
    {
      get { return _ArrowWidth; }
      set { _ArrowWidth = value; Invalidate(); }
    }

    private int _ArrowHeight = 8;
    [Description("Height of the arrow")]
    [Category("Appearance")]
    public int ArrowHeight
    {
      get { return _ArrowHeight; }
      set { _ArrowHeight = value; Invalidate(); }
    }

    private int _FitControlPadding = 3;
    [Description("Padding of fitted control")]
    [Category("Appearance")]
    public int FitControlPadding
    {
      get { return _FitControlPadding; }
      set { _FitControlPadding = value; }
    }

    public event EventHandler AutoClosed;

    public FlatArrowContainer()
    {
      InitializeComponent();
    }

    public void ShowOverControl(Control ctl)
    {
      Point pt = ctl.FindForm().PointToClient(ctl.Parent.PointToScreen(ctl.Location));
      Location = new Point(
        pt.X + ctl.Size.Width / 2 - Size.Width / 2,
        pt.Y + ctl.Size.Height
      );
    }

    public void FitChild(Control ctl)
    {
      ctl.Left = _FitControlPadding;
      ctl.Top = ArrowHeight + _FitControlPadding;
      ctl.Width = Size.Width - _FitControlPadding * 2;
      ctl.Height = Size.Height - ArrowHeight - _FitControlPadding * 2;
    }

    public void OpenOverControl(Control ctl, Control parent, Control child)
    {
      FitChild(child);
      Controls.Add(child);

      parent.Controls.Add(this);
      ShowOverControl(ctl);
      BringToFront();

      child.Focus();
      Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      // Don't draw background
      //base.OnPaintBackground(e);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x00000008; // WS_EX_TOPMOST
        //cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
        return cp;
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      Invalidate();
      base.OnMouseMove(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      Invalidate();
      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      if (_AutoDisappear && Parent != null) {
        if (GetChildAtPoint(PointToClient(Cursor.Position)) == null) {
          Parent.Controls.Remove(this);
          if (AutoClosed != null) {
            AutoClosed(this, new EventArgs());
          }
        }
      }

      base.OnMouseLeave(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int arrowMid = Size.Width / 2;
      int arrowLeft = arrowMid - _ArrowWidth;
      int arrowRight = arrowMid + _ArrowWidth;

      int right = Size.Width - 1;
      int bottom = Size.Height - 1;

      Point[] polygon = new Point[] {
        new Point(0, _ArrowHeight),
        new Point(arrowLeft, _ArrowHeight),
        new Point(arrowMid, 0),
        new Point(arrowRight, _ArrowHeight),
        new Point(right, _ArrowHeight),

        new Point(right, bottom),
        new Point(0, bottom),
        new Point(0, _ArrowHeight),
      };

      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (SolidBrush brush = new SolidBrush(BackColor)) {
        e.Graphics.FillPolygon(brush, polygon);
      }
      using (Pen pen = new Pen(_BorderColor)) {
        e.Graphics.DrawPolygon(pen, polygon);
      }

      base.OnPaint(e);
    }
  }
}
