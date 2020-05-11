using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nimble.Controls
{
  public partial class DraggablePictureBox : UserControl
  {
    private Image _image = null;
    [Category("Draggable")]
    [Description("Image to use")]
    public Image Image
    {
      get { return _image; }
      set
      {
        _image = value;
        RecreateHandle();
      }
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

    private bool _allowDragging = true;
    [Category("Draggable")]
    [Description("Allow dragging with the mouse")]
    [DefaultValue(true)]
    public bool AllowDragging
    {
      get { return _allowDragging; }
      set { _allowDragging = value; }
    }

    private bool _allowZooming = true;
    [Category("Draggable")]
    [Description("Allow zooming with the scrollwheel")]
    [DefaultValue(true)]
    public bool AllowZooming
    {
      get { return _allowZooming; }
      set { _allowZooming = value; }
    }

    private bool _startFit = false;
    [Category("Draggable")]
    [Description("Start with fit in container")]
    public bool StartFit
    {
      get { return _startFit; }
      set
      {
        _startFit = value;
        RecreateHandle();
      }
    }

    public DraggablePictureBox()
    {
      InitializeComponent();
    }

    public int CurrentX { get; set; }
    public int CurrentY { get; set; }

    [DefaultValue(1.0)]
    public double CurrentScale { get; set; }

    private bool _dragging = false;
    private Point _prevPoint = Point.Empty;

    public void FitInContainer()
    {
      Reset();
      if (_image == null) {
        return;
      }
      double scaleWidth = this.Width / (double)_image.Width;
      double scaleHeight = this.Height / (double)_image.Height;
      double scale = 1.0;
      if (scaleWidth < scaleHeight) {
        scale = scaleWidth;
      } else {
        scale = scaleHeight;
      }
      CurrentScale = Math.Min(1.0, scale);
      Center();
    }

    public void Center()
    {
      if (_image == null) {
        return;
      }
      CurrentX = (int)(this.Width / 2 - (_image.Width * CurrentScale) / 2);
      CurrentY = (int)(this.Height / 2 - (_image.Height * CurrentScale) / 2);
      Invalidate();
    }

    public void Reset()
    {
      CurrentX = 0;
      CurrentY = 0;
      CurrentScale = 1.0;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      this.BorderStyle = BorderStyle.None;
    }

    private void DraggablePictureBox_Paint(object sender, PaintEventArgs e)
    {
      if (_image == null) {
        DrawBorder(e.Graphics);
        return;
      }

      int x = CurrentX;
      int y = CurrentY;
      int w = (int)(_image.Width * CurrentScale);
      int h = (int)(_image.Height * CurrentScale);

      e.Graphics.DrawImage(_image, x, y, w, h);

      DrawBorder(e.Graphics);
    }

    private void DrawBorder(Graphics g)
    {
      if (_HasBorders) {
        using (Pen pen = new Pen(_BorderColor)) {
          g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
      }
    }

    private void DraggablePictureBox_Resize(object sender, EventArgs e)
    {
      if (DesignMode) {
        Refresh();
      } else {
        Invalidate();
      }
    }

    private void DraggablePictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (!_allowDragging) {
        return;
      }

      if (e.Button == MouseButtons.Left) {
        _dragging = true;
        _prevPoint = e.Location;
      }

      if (e.Button == MouseButtons.Middle && _startFit) {
        FitInContainer();
      }
    }

    private void DraggablePictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (!_allowDragging || !_dragging) {
        return;
      }

      int iDeltaX = e.Location.X - _prevPoint.X;
      int iDeltaY = e.Location.Y - _prevPoint.Y;
      CurrentX += iDeltaX;
      CurrentY += iDeltaY;

      _prevPoint = e.Location;

      Invalidate();
    }

    private void DraggablePictureBox_MouseUp(object sender, MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (!_allowDragging) {
        return;
      }

      _dragging = false;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (!_allowZooming || _dragging) {
        return;
      }

      if (_image == null) {
        return;
      }

      double overX = ((e.Location.X - CurrentX) / (CurrentScale * _image.Width));
      double overY = ((e.Location.Y - CurrentY) / (CurrentScale * _image.Height));

      double newScale = CurrentScale;
      if (e.Delta < 0) {
        newScale *= 0.8;
      } else {
        newScale *= 1.2;
      }
      if (newScale < 0.1) {
        newScale = 0.1;
      }
      CurrentX -= (int)(((newScale - CurrentScale) * _image.Width) * overX);
      CurrentY -= (int)(((newScale - CurrentScale) * _image.Height) * overY);
      CurrentScale = newScale;

      Invalidate();
    }

    private void DraggablePictureBox_Load(object sender, EventArgs e)
    {
      if (StartFit) {
        FitInContainer();
      } else {
        CurrentScale = 1.0;
      }
    }
  }
}
