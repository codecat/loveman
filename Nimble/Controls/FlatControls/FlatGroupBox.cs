using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Nimble.Controls.FlatControls
{
  [Designer(typeof(FlatGroupBoxDesigner))]
  [DefaultProperty("Title")]
  public class FlatGroupBox : Control
  {
    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private bool _HasBorders = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    private int _TopPadding = 10;
    [Description("Padding at the top")]
    [Category("Appearance")]
    public int TopPadding
    {
      get { return _TopPadding; }
      set { _TopPadding = value; Invalidate(); }
    }

    private int _LeftPadding = 10;
    [Description("Padding at the left")]
    [Category("Appearance")]
    public int LeftPadding
    {
      get { return _LeftPadding; }
      set { _LeftPadding = value; Invalidate(); }
    }

    private string _Title = "";
    [Description("Text")]
    [Category("Appearance")]
    public string Title
    {
      get { return _Title; }
      set { _Title = value; Invalidate(); }
    }

    private int _TextPadding = 2;
    [Description("Padding between text and lines")]
    [Category("Appearance")]
    public int TextPadding
    {
      get { return _TextPadding; }
      set { _TextPadding = value; Invalidate(); }
    }

    public FlatGroupBox()
      : base()
    {
      SetStyle(ControlStyles.ContainerControl, true);
      SetStyle(ControlStyles.Selectable, false);
    }

    protected override Size DefaultSize
    {
      get { return new Size(200, 100); }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        return new Rectangle(
          3, _TopPadding + (int)Font.Size,
          this.Width - 6, this.Height - _TopPadding - (int)Font.Size
        );
      }
    }

    protected override void OnResize(EventArgs e)
    {
      Invalidate();
      base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Size szText = e.Graphics.MeasureString(_Title, Font).ToSize();

      if (_HasBorders) {
        using (Pen pen = new Pen(_BorderColor)) {
          e.Graphics.DrawRectangle(pen, new Rectangle(0, _TopPadding, this.Width - 1, this.Height - _TopPadding - 1));
        }
      }

      if (_Title != "") {
        using (SolidBrush brush = new SolidBrush(BackColor)) {
          e.Graphics.FillRectangle(brush, new Rectangle(_LeftPadding, _TopPadding - szText.Height / 2, szText.Width + _TextPadding * 2, szText.Height));
        }
        using (SolidBrush brush = new SolidBrush(ForeColor)) {
          e.Graphics.DrawString(_Title, Font, brush, new PointF(_LeftPadding + _TextPadding, _TopPadding - szText.Height / 2));
        }
      }

      base.OnPaint(e);
    }
  }

  public class FlatGroupBoxDesigner : ParentControlDesigner
  {

  }
}
