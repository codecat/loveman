using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Nimble.Controls
{
  public class ExtendedComboBox : ComboBox
  {
    private bool _HasBorders = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    private Color _BorderColor = SystemColors.Window;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _BorderColorActive = SystemColors.Window;
    [Description("Color of the active border")]
    [Category("Appearance")]
    public Color BorderColorActive
    {
      get { return _BorderColorActive; }
      set { _BorderColorActive = value; Invalidate(); }
    }

    private Color _BorderColorDisabled = SystemColors.ControlDark;
    [Description("Color of the disabled border")]
    [Category("Appearance")]
    public Color BorderColorDisabled
    {
      get { return _BorderColorDisabled; }
      set { _BorderColorDisabled = value; Invalidate(); }
    }

    public ExtendedComboBox()
    {
      ControlUtils.ImplementWordBackspacing(this);
    }

    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == NativeMethods.WM_PAINT) {
        OnWmPaint();
      }
    }

    private void OnWmPaint()
    {
      using (Graphics g = CreateGraphics()) {
        if (!_HasBorders) {
          using (Pen pen = new Pen(BackColor)) {
            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          }
          return;
        }
        if (!Enabled) {
          using (Pen pen = new Pen(_BorderColorDisabled)) {
            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          }
          return;
        }
        if (ContainsFocus) {
          using (Pen pen = new Pen(_BorderColorActive)) {
            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          }
          return;
        }
        using (Pen pen = new Pen(_BorderColor)) {
          g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
      }
    }
  }
}
