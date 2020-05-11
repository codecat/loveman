using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nimble.Extensions;
using Nimble.Drawing;

namespace Nimble.Controls.FlatControls
{
  [DefaultEvent("Click")]
  public partial class FlatButton : UserControl
  {
    private string _Text = "";
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    public override string Text
    {
      get { return _Text; }
      set { _Text = value; Invalidate(); }
    }

    private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
    [Description("Text alignment")]
    [Category("Appearance")]
    public ContentAlignment TextAlign
    {
      get { return _TextAlign; }
      set { _TextAlign = value; Invalidate(); }
    }

    private int _TextPadding = 3;
    [Description("Padding of the text")]
    [Category("Appearance")]
    public int TextPadding
    {
      get { return _TextPadding; }
      set { _TextPadding = value; Invalidate(); }
    }

    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _BackShadeColor = SystemColors.Control;
    public Color BackShadeColor
    {
      get { return _BackShadeColor; }
      set { _BackShadeColor = value; Invalidate(); }
    }

    private double _BackShadeRatio = 0.0f;
    public double BackShadeRatio
    {
      get { return _BackShadeRatio; }
      set { _BackShadeRatio = value; Invalidate(); }
    }

    private Color _BackColorOver = Color.DarkGray;
    [Description("Background color of the button when hovering over it")]
    [Category("Appearance")]
    public Color BackColorOver
    {
      get { return _BackColorOver; }
      set { _BackColorOver = value; }
    }

    private Color _BackColorDown = Color.White;
    [Description("Background color of the button when mouse is down")]
    [Category("Appearance")]
    public Color BackColorDown
    {
      get { return _BackColorDown; }
      set { _BackColorDown = value; }
    }

    private bool _HasBorder = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorder
    {
      get { return _HasBorder; }
      set { _HasBorder = value; Invalidate(); }
    }

    private Image _Image = null;
    [Description("Image to render with the button")]
    [Category("Appearance")]
    public Image Image
    {
      get { return _Image; }
      set { _Image = value; Invalidate(); }
    }

    private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
    [Description("Alignment of the image")]
    [Category("Appearance")]
    public ContentAlignment ImageAlign
    {
      get { return _ImageAlign; }
      set { _ImageAlign = value; Invalidate(); }
    }

    private int _ImagePadding = 3;
    [Description("Padding of the image")]
    [Category("Appearance")]
    public int ImagePadding
    {
      get { return _ImagePadding; }
      set { _ImagePadding = value; Invalidate(); }
    }

    private FlatTextImageRelation _TextImageRelation = FlatTextImageRelation.Normal;
    [Description("Text appears before or after the image")]
    [Category("Appearance")]
    public FlatTextImageRelation TextImageRelation
    {
      get { return _TextImageRelation; }
      set { _TextImageRelation = value; Invalidate(); }
    }

    public new event EventHandler Click;

    private FlatButtonState _bsState = FlatButtonState.Normal;
    private FlatButtonState bsState
    {
      get { return _bsState; }
      set
      {
        if (_bsState != value) {
          _bsState = value;
          Invalidate();
        }
      }
    }
    public FlatButtonState ButtonState { get { return bsState; } }

    public FlatButton()
    {
      InitializeComponent();

      this.DoubleBuffered = true;
    }

    public void PerformClick()
    {
      if (Click != null) {
        Click(this, null);
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left) {
        bsState = FlatButtonState.Down;
      }

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && bsState == FlatButtonState.Down) {
        bsState = FlatButtonState.Over;

        if (Click != null) {
          Click(this, e);
        }
      }

      base.OnMouseUp(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      bsState = FlatButtonState.Over;

      base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      bsState = FlatButtonState.Normal;

      base.OnMouseLeave(e);
    }

    private void DrawTextNormal(Size szText, Rectangle rect, PaintEventArgs e)
    {
      Rectangle rectText = LayoutUtils.Align(szText + new Size(_TextPadding * 2, _TextPadding * 2), rect, _TextAlign);
      rectText.X += _TextPadding;
      rectText.Y += _TextPadding;
      using (SolidBrush brush = new SolidBrush(this.ForeColor)) {
        e.Graphics.DrawString(_Text, this.Font, brush, rectText.Location);
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (bsState == FlatButtonState.Down) {
        e.Graphics.Clear(_BackColorDown.Lerp(_BackShadeColor, _BackShadeRatio));
      } else if (bsState == FlatButtonState.Over) {
        e.Graphics.Clear(_BackColorOver.Lerp(_BackShadeColor, _BackShadeRatio));
      } else {
        e.Graphics.Clear(this.BackColor.Lerp(_BackShadeColor, _BackShadeRatio));
      }

      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
      Size szText = e.Graphics.MeasureString(_Text, this.Font).ToSize();

      if (_Image != null) {
        Rectangle rectImage = LayoutUtils.Align(_Image.Size + new Size(_ImagePadding * 2, _ImagePadding * 2), rect, _ImageAlign);
        rectImage.X += _ImagePadding;
        rectImage.Y += _ImagePadding;
        e.Graphics.DrawImage(_Image, new Rectangle(rectImage.Location, _Image.Size));
        if (_TextImageRelation == FlatTextImageRelation.After) {
          using (SolidBrush brush = new SolidBrush(this.ForeColor)) {
            e.Graphics.DrawString(_Text, this.Font, brush, new Point(
              rectImage.X + _Image.Width + _ImagePadding,
              rectImage.Y + _Image.Height / 2 - szText.Height / 2
            ));
          }
        } else if (_TextImageRelation == FlatTextImageRelation.Before) {
          using (SolidBrush brush = new SolidBrush(this.ForeColor)) {
            e.Graphics.DrawString(_Text, this.Font, brush, new Point(
              rectImage.X - szText.Width - _ImagePadding,
              rectImage.Y + _Image.Height / 2 - szText.Height / 2
            ));
          }
        } else {
          DrawTextNormal(szText, rect, e);
        }
      } else {
        DrawTextNormal(szText, rect, e);
      }

      if (_HasBorder) {
        using (Pen pen = new Pen(_BorderColor)) {
          e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
      }

      base.OnPaint(e);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      Refresh();
    }
  }
}
