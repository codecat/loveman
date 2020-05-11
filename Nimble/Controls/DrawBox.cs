using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Nimble.Controls.FlatControls;
using Nimble.Extensions;
using Nimble.Drawing;
using Nimble.Dialogs;

namespace Nimble.Controls
{
  public enum DrawBoxTools
  {
    None,
    Brush,
    Eraser
  }

  public class DrawBox : Control
  {
    private Bitmap _bitmap = null;

    private DrawBoxTools _CurrentTool = DrawBoxTools.None;
    public DrawBoxTools CurrentTool
    {
      get { return _CurrentTool; }
      set
      {
        _CurrentTool = value;
        if (_ShowButtons) {
          double fNormalRatio = 0.1;
          double fSelectedRatio = 0.4;
          _buttonBrush.BackShadeRatio = _CurrentTool == DrawBoxTools.Brush ? fSelectedRatio : fNormalRatio;
          _buttonEraser.BackShadeRatio = _CurrentTool == DrawBoxTools.Eraser ? fSelectedRatio : fNormalRatio;
        }
        UpdateCursor();
      }
    }

    public Image Image
    {
      get { return _bitmap; }
      set
      {
        if (value == null) {
          CreateBitmap();
        } else {
          _bitmap = (Bitmap)value;
          Invalidate();
        }
      }
    }

    private void UpdateCursor()
    {
      if (_CurrentTool == DrawBoxTools.Brush || _CurrentTool == DrawBoxTools.Eraser) {
        this.Cursor = CreateBrushCursor();
      } else {
        this.Cursor = Cursors.Default;
      }
    }

    private Cursor CreateBrushCursor()
    {
      int size = Math.Max(13, _BrushDiameter) + 5;
      if (size % 2 == 0) {
        size++;
      }
      int mid = (int)Math.Ceiling(size / 2.0) - 1;
      int diameter = _BrushDiameter;
      int radius = diameter / 2;
      int ellipsepos = mid - radius;

      Bitmap bmp = new Bitmap(size, size);
      using (Graphics g = Graphics.FromImage(bmp)) {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        SolidBrush brushWhite = new SolidBrush(Color.White);
        Pen penWhite3 = new Pen(Color.White, 3);
        Pen penBlack = new Pen(Color.Black);

        g.DrawEllipse(penWhite3, ellipsepos, ellipsepos, diameter, diameter);
        g.DrawEllipse(penBlack, ellipsepos, ellipsepos, diameter, diameter);

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

        g.FillRectangle(brushWhite, new Rectangle(mid - 6, mid - 1, 6, 3));
        g.FillRectangle(brushWhite, new Rectangle(mid + 1, mid - 1, 6, 3));
        g.FillRectangle(brushWhite, new Rectangle(mid - 1, mid - 6, 3, 6));
        g.FillRectangle(brushWhite, new Rectangle(mid - 1, mid + 1, 3, 6));
        g.DrawLine(penBlack, new Point(mid - 5, mid), new Point(mid - 1, mid));
        g.DrawLine(penBlack, new Point(mid + 1, mid), new Point(mid + 5, mid));
        g.DrawLine(penBlack, new Point(mid, mid - 5), new Point(mid, mid - 1));
        g.DrawLine(penBlack, new Point(mid, mid + 1), new Point(mid, mid + 5));

        brushWhite.Dispose();
        penWhite3.Dispose();
        penBlack.Dispose();
      }

      return new Cursor(bmp.GetHicon());
    }

    private FlatButton _buttonClear;

    private FlatButton _buttonBrush;
    private FlatButton _buttonEraser;

    private FlatButton _buttonColorPrimary;
    private FlatButton _buttonColorSecondary;

    private int _BrushDiameter = 6;
    public int BrushDiameter
    {
      get { return _BrushDiameter; }
      set
      {
        _BrushDiameter = value;
        UpdateCursor();
      }
    }

    private Color _ColorPrimary = Color.Black;
    public Color ColorPrimary
    {
      get { return _ColorPrimary; }
      set
      {
        _ColorPrimary = value;
        if (_buttonColorPrimary != null) {
          _buttonColorPrimary.BackShadeColor = _ColorPrimary;
        }
      }
    }

    private Color _ColorSecondary = Color.White;
    public Color ColorSecondary
    {
      get { return _ColorSecondary; }
      set
      {
        _ColorSecondary = value;
        if (_buttonColorSecondary != null) {
          _buttonColorSecondary.BackShadeColor = _ColorSecondary;
        }
      }
    }

    private bool _ShowButtons = false;
    public bool ShowButtons
    {
      get { return _ShowButtons; }
      set { _ShowButtons = value; Reloadbuttons(); }
    }

    private bool _HasBorders = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    private Color _BorderColor = SystemColors.WindowFrame;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private bool _Editable = true;
    public bool Editable
    {
      get { return _Editable; }
      set { _Editable = value; }
    }

    public DrawBox()
    {
      this.BackColor = Color.White;
      this.ForeColor = Color.Black;
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    }

    public void Reloadbuttons()
    {
      this.Controls.Clear();

      if (_ShowButtons) {
        _buttonClear = new FlatButton();
        _buttonClear.Location = new Point(3, 3);
        _buttonClear.Text = "Clear";
        _buttonClear.BackShadeColor = Color.White;
        _buttonClear.BackShadeRatio = 0.1;
        _buttonClear.Click += new EventHandler((o, e) => {
          CreateBitmap();
          CurrentTool = DrawBoxTools.None;
        });
        this.Controls.Add(_buttonClear);

        _buttonBrush = new FlatButton();
        _buttonBrush.Location = new Point(_buttonClear.Right + 3, 3);
        _buttonBrush.Text = "Brush";
        _buttonBrush.BackShadeColor = Color.Yellow;
        _buttonBrush.BackShadeRatio = 0.1;
        _buttonBrush.Click += new EventHandler((o, e) => {
          if (CurrentTool == DrawBoxTools.Brush) {
            CurrentTool = DrawBoxTools.None;
          } else {
            CurrentTool = DrawBoxTools.Brush;
          }
        });
        this.Controls.Add(_buttonBrush);

        _buttonEraser = new FlatButton();
        _buttonEraser.Location = new Point(_buttonBrush.Right + 3, 3);
        _buttonEraser.Text = "Eraser";
        _buttonEraser.BackShadeColor = Color.Pink;
        _buttonEraser.BackShadeRatio = 0.1;
        _buttonEraser.Click += new EventHandler((o, e) => {
          if (CurrentTool == DrawBoxTools.Eraser) {
            CurrentTool = DrawBoxTools.None;
          } else {
            CurrentTool = DrawBoxTools.Eraser;
          }
        });
        this.Controls.Add(_buttonEraser);

        _buttonColorSecondary = new FlatButton();
        _buttonColorSecondary.Width = _buttonColorSecondary.Height;
        _buttonColorSecondary.Location = new Point(this.Width - _buttonColorSecondary.Width - 3, 3 + _buttonColorSecondary.Height / 3);
        _buttonColorSecondary.BackShadeColor = _ColorSecondary;
        _buttonColorSecondary.BackShadeRatio = 1.0;
        _buttonColorSecondary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttonColorSecondary.Click += new EventHandler((o, e) => {
          FormColorPicker dlg = new FormColorPicker();
          dlg.Color = _ColorSecondary;
          if (dlg.ShowDialog(this) != DialogResult.OK) {
            return;
          }
          _buttonColorSecondary.BackShadeColor = _ColorSecondary = dlg.Color;
        });
        this.Controls.Add(_buttonColorSecondary);

        _buttonColorPrimary = new FlatButton();
        _buttonColorPrimary.Width = _buttonColorPrimary.Height;
        _buttonColorPrimary.Location = new Point(_buttonColorSecondary.Left - (int)(_buttonColorPrimary.Width * 0.6), 3);
        _buttonColorPrimary.BackShadeColor = _ColorPrimary;
        _buttonColorPrimary.BackShadeRatio = 1.0;
        _buttonColorPrimary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttonColorPrimary.Click += new EventHandler((o, e) => {
          FormColorPicker dlg = new FormColorPicker();
          dlg.Color = _ColorPrimary;
          if (dlg.ShowDialog(this) != DialogResult.OK) {
            return;
          }
          _buttonColorPrimary.BackShadeColor = _ColorPrimary = dlg.Color;
        });
        this.Controls.Add(_buttonColorPrimary);
        _buttonColorPrimary.BringToFront();
      }
    }

    protected override Size DefaultSize
    {
      get { return new Size(400, 350); }
    }

    private Point _ptPrevious = Point.Empty;

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (DesignMode || !_Editable) {
        return;
      }

      if (_bitmap == null) {
        CreateBitmap();
      }

      if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) {
        return;
      }

      Color colBrush = e.Button == MouseButtons.Right ? _ColorSecondary : _ColorPrimary;
      float fRadius = _BrushDiameter / 2.0f;

      if (_CurrentTool == DrawBoxTools.Brush) {
        using (Graphics g = Graphics.FromImage(_bitmap)) {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          using (SolidBrush brush = new SolidBrush(colBrush)) {
            g.FillEllipse(brush, e.X - fRadius, e.Y - fRadius, _BrushDiameter, _BrushDiameter);
          }
        }
        Invalidate();

      } else if (_CurrentTool == DrawBoxTools.Eraser) {
        using (Graphics g = Graphics.FromImage(_bitmap)) {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
          using (SolidBrush brush = new SolidBrush(Color.Transparent)) {
            g.FillEllipse(brush, e.X - fRadius, e.Y - fRadius, _BrushDiameter, _BrushDiameter);
          }
        }
        Invalidate();
      }

      _ptPrevious = e.Location;

      base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (DesignMode || !_Editable) {
        return;
      }

      if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) {
        return;
      }

      Color colBrush = e.Button == MouseButtons.Right ? _ColorSecondary : _ColorPrimary;

      if (_CurrentTool == DrawBoxTools.Brush) {
        using (Graphics g = Graphics.FromImage(_bitmap)) {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          using (Pen pen = new Pen(colBrush, _BrushDiameter) {
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
            EndCap = System.Drawing.Drawing2D.LineCap.Round
          }) {
            g.DrawLine(pen, _ptPrevious, e.Location);
          }
        }
        Invalidate();

      } else if (_CurrentTool == DrawBoxTools.Eraser) {
        using (Graphics g = Graphics.FromImage(_bitmap)) {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
          using (Pen pen = new Pen(Color.Transparent, _BrushDiameter) {
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
            EndCap = System.Drawing.Drawing2D.LineCap.Round
          }) {
            g.DrawLine(pen, _ptPrevious, e.Location);
          }
        }
        Invalidate();
      }

      _ptPrevious = e.Location;

      base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (DesignMode || !_Editable) {
        return;
      }

      base.OnMouseUp(e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.OemOpenBrackets) {
        if (_BrushDiameter > 1) {
          BrushDiameter--;
        }
      } else if (keyData == (Keys.OemOpenBrackets | Keys.Shift)) {
        if (_BrushDiameter > 4) {
          BrushDiameter -= 4;
        }
      } else if (keyData == Keys.OemCloseBrackets) {
        BrushDiameter++;
      } else if (keyData == (Keys.OemCloseBrackets | Keys.Shift)) {
        BrushDiameter += 4;
      } else if (keyData == Keys.B) {
        _buttonBrush.PerformClick();
      } else if (keyData == Keys.E) {
        _buttonEraser.PerformClick();
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void CreateBitmap()
    {
      if (_bitmap != null) {
        _bitmap.Dispose();
      }
      _bitmap = new Bitmap(Math.Max(1, this.Width), Math.Max(1, this.Height));
      Invalidate();
    }

    private void ResizeBitmap()
    {
      Bitmap bmpNew = new Bitmap(Math.Max(0, Math.Max(_bitmap.Width, this.Width)), Math.Max(0, Math.Max(_bitmap.Height, this.Height)));
      using (Graphics g = Graphics.FromImage(bmpNew)) {
        g.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
      }
      _bitmap.Dispose();
      _bitmap = bmpNew;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (_bitmap == null) {
        CreateBitmap();
      }
      if (this.Width > _bitmap.Width || this.Height > _bitmap.Height) {
        ResizeBitmap();
      }
      e.Graphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));

      base.OnPaint(e);

      if (_HasBorders) {
        ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width, this.Height), _BorderColor, ButtonBorderStyle.Solid);
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      if (_bitmap != null && (this.Width > _bitmap.Width || this.Height > _bitmap.Height)) {
        ResizeBitmap();
      }

      Refresh();
    }
  }
}
