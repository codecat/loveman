using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nimble.Controls
{
  public class DraggableGraph : Control
  {
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<DataPoint> Dataset { get; set; } = new List<DataPoint>();

    public class DataPoint
    {
      public int m_value;
      public string m_label;
    }

    public int ViewMin { get; set; } = -1;
    public int ViewMax { get; set; } = -1;

    private int _ViewStart = 0;
    public int ViewStart
    {
      get { return _ViewStart; }
      set {
        if (_ViewStart != value) {
          _ViewStart = value;
          Invalidate();
        }
      }
    }

    private int _ViewCount = 100;
    public int ViewCount
    {
      get { return _ViewCount; }
      set {
        if (MinViewCount != -1 && value < MinViewCount) {
          value = MinViewCount;
        } else if (MaxViewCount != -1 && value > MaxViewCount) {
          value = MaxViewCount;
        }

        if (_ViewCount != value) {
          _ViewCount = value;
          Invalidate();
        }
      }
    }

    public int ViewCountScrollStep { get; set; } = 10;
    public int MinViewCount { get; set; } = 8;
    public int MaxViewCount { get; set; } = -1;

    public int ViewEnd
    {
      get { return ViewStart + ViewCount; }
      set { ViewCount = value - ViewStart; }
    }

    private int _InfoHeight = 100;
    public int InfoHeight
    {
      get { return _InfoHeight; }
      set {
        if (_InfoHeight != value) {
          _InfoHeight = value;
          Invalidate();
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ViewRect
    {
      get { return new Rectangle(0, 0, Width - 1, Height - InfoHeight); }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle InfoRect
    {
      get { return new Rectangle(0, Height - InfoHeight, Width - 1, InfoHeight); }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public float ValuePadding
    {
      get { return ViewRect.Width / (float)ViewCount; }
    }

    private float _ExtraOffsetX = 0.0f;
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public float OffsetX
    {
      get {
        return (ViewStart * ValuePadding) + _ExtraOffsetX;
      }
      set {
        float valuePadding = ValuePadding;

        float diff = value - OffsetX;
        _ExtraOffsetX += diff;

        if (diff < 0) {
          while (_ExtraOffsetX < 0) {
            _ExtraOffsetX += valuePadding;
            ViewStart--;
          }
        } else if (diff > 0) {
          while (_ExtraOffsetX > valuePadding) {
            _ExtraOffsetX -= valuePadding;
            ViewStart++;
          }
        }

        TestBoundaries();

        Invalidate();
      }
    }

    private Color _LineColor = Color.Blue;
    public Color LineColor
    {
      get { return _LineColor; }
      set {
        _LineColor = value;
        Invalidate();
      }
    }

    private Color _DotColor = Color.Green;
    public Color DotColor
    {
      get { return _DotColor; }
      set {
        _DotColor = value;
        Invalidate();
      }
    }

    private Color _BorderColor = Color.Green;
    public Color BorderColor
    {
      get { return _BorderColor; }
      set {
        _BorderColor = value;
        Invalidate();
      }
    }

    private bool m_dragging = false;
    private int m_draggingX = 0;

    public DraggableGraph()
    {
      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    }

    public void TestBoundaries()
    {
      if (ViewEnd >= Dataset.Count) {
        ViewStart = Dataset.Count - ViewCount;
        if (ViewStart < 0) {
          ViewStart = 0;
          ViewCount = Dataset.Count;
        }
        _ExtraOffsetX = 0;
      } else if (ViewStart < 0) {
        ViewStart = 0;
        _ExtraOffsetX = 0;
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (DesignMode) {
        return;
      }

      m_dragging = true;
      m_draggingX = e.X;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (DesignMode) {
        return;
      }

      if (m_dragging) {
        OffsetX += (m_draggingX - e.X);
        m_draggingX = e.X;
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      if (DesignMode) {
        return;
      }

      m_dragging = false;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);

      if (DesignMode) {
        return;
      }

      var viewRect = ViewRect;
      float scale = (e.X - viewRect.X) / (float)viewRect.Width;
      if (scale < 0.0f || scale > 1.0f) {
        return;
      }

      int lastcount = ViewCount;
      int countDiff = 0;
      if (e.Delta < 0) {
        ViewCount += ViewCountScrollStep;
      } else if (e.Delta > 0) {
        ViewCount -= ViewCountScrollStep;
      }
      countDiff = lastcount - ViewCount;

      ViewStart += (int)(countDiff * scale);

      TestBoundaries();
    }

    protected override void OnResize(EventArgs e)
    {
      Invalidate();
      base.OnResize(e);
    }

    private Point GetPoint(int v, int index, int min, int max)
    {
      var viewRect = ViewRect;

      float scalar = (v - min) / (float)(max - min);
      int x = viewRect.X + (int)(index * ValuePadding - _ExtraOffsetX);
      int y = viewRect.Y + viewRect.Height - (int)(scalar * viewRect.Height);

      return new Point(x, y);
    }

    private void DrawLines(Graphics g, int min = -1, int max = -1)
    {
      int index = 0;
      if (ViewStart > 0) {
        index = -1;
      }

      var viewSet = Dataset.Skip(ViewStart + index).Take(ViewCount - index + 2);

      if (min == -1) {
        min = viewSet.Min(dp => dp.m_value);
      }

      if (max == -1) {
        max = viewSet.Max(dp => dp.m_value);
      }

      using (var pen = new Pen(LineColor)) {
        var viewSetArr = viewSet.ToArray();
        for (int i = 0; i < viewSetArr.Length - 1; i++) {
          var p1 = GetPoint(viewSetArr[i].m_value, index, min, max);
          var p2 = GetPoint(viewSetArr[i + 1].m_value, index + 1, min, max);

          g.DrawLine(pen, p1, p2);

          index++;
        }
      }
    }

    private void DrawDots(Graphics g, int min = -1, int max = -1)
    {
      var viewSet = Dataset.Skip(ViewStart).Take(ViewCount + 1);

      if (min == -1) {
        min = viewSet.Min(dp => dp.m_value);
      }

      if (max == -1) {
        max = viewSet.Max(dp => dp.m_value);
      }

      int index = 0;

      using (var brush = new SolidBrush(DotColor)) {
        foreach (var v in viewSet) {
          var p = GetPoint(v.m_value, index, min, max);
          g.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);
          index++;
        }
      }
    }

    private void DrawInfo(Graphics g, int min = -1, int max = -1)
    {
      var viewSet = Dataset.Take(ViewEnd).Reverse();

      if (min == -1) {
        min = viewSet.Min(dp => dp.m_value);
      }

      if (max == -1) {
        max = viewSet.Max(dp => dp.m_value);
      }

      var viewRect = ViewRect;
      var infoRect = InfoRect;

      using (var brush = new SolidBrush(ForeColor)) {
        using (var pen = new Pen(BorderColor)) {
          int index = ViewEnd - 1;

          int lastIndex = 0;
          DataPoint lastPoint = null;

          foreach (var v in viewSet) {
            if (v.m_label != null) {
              var p = GetPoint(v.m_value, index - ViewStart, min, max);
              if (p.X >= 0) {
                g.DrawLine(pen, new Point(p.X, 0), new Point(p.X, Height));
              }

              var textSize = g.MeasureString(v.m_label, Font);
              int textOffset = 0;

              if (p.X < 0) {
                if (lastPoint != null) {
                  var lp = GetPoint(lastPoint.m_value, lastIndex - ViewStart, min, max);
                  var blockWidth = lp.X - p.X;
                  var blockOffset = p.X;
                  textOffset = Math.Min(blockWidth - (int)(textSize.Width + 8), -blockOffset);
                }
              } else {
                textOffset = 0;
              }

              g.DrawString(v.m_label, Font, brush, infoRect.X + p.X + 4 + textOffset, infoRect.Y + 4);

              if (textOffset > 0) {
                break;
              }

              lastIndex = index;
              lastPoint = v;
            }
            index--;
          }
        }
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.Clear(BackColor);
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

      var viewRect = ViewRect;

      using (var pen = new Pen(BorderColor)) {
        e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
        e.Graphics.DrawLine(pen, new Point(0, Height - InfoHeight), new Point(Width - 1, Height - InfoHeight));
      }

      if (Dataset.Count > 0) {
        int viewMin = ViewMin;
        int viewMax = ViewMax;

        if (viewMin == -1) {
          viewMin = Dataset.Min(dp => dp.m_value);
        }
        if (viewMax == -1) {
          viewMax = Dataset.Max(dp => dp.m_value);
        }

        if (viewMax < 10) {
          viewMax = 10;
        }
        if (viewMin == viewMax) {
          viewMax++;
        }

        DrawInfo(e.Graphics, viewMin, viewMax);
        DrawLines(e.Graphics, viewMin, viewMax);
        DrawDots(e.Graphics, viewMin, viewMax);

        using (var brush = new SolidBrush(ForeColor)) {
          e.Graphics.DrawString("" + viewMax, Font, brush, viewRect.X, viewRect.Y);
          e.Graphics.DrawString("" + viewMin, Font, brush, viewRect.X, viewRect.Y + ViewRect.Height - Font.Height);
        }
      }

      base.OnPaint(e);
    }
  }
}
