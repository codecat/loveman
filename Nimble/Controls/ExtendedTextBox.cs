using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Nimble.Controls
{
  public class ExtendedTextBox : TextBox
  {
    private bool _HasBorders = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    private Color _BorderColor = SystemColors.InactiveBorder;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _BorderColorActive = SystemColors.ActiveBorder;
    [Description("Color of the active border")]
    [Category("Appearance")]
    public Color BorderColorActive
    {
      get { return _BorderColorActive; }
      set { _BorderColorActive = value; Invalidate(); }
    }

    public new BorderStyle BorderStyle
    {
      get { return BorderStyle.Fixed3D; }
    }

    public ExtendedTextBox()
    {
      ControlUtils.ImplementWordBackspacing(this);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (DesignMode) {
        return;
      }
      NativeMethods.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, NativeMethods.RedrawWindowFlags.Frame | NativeMethods.RedrawWindowFlags.UpdateNow | NativeMethods.RedrawWindowFlags.Invalidate);
    }

    protected override void WndProc(ref Message m)
    {
      if (!DesignMode) {
        if (m.Msg == NativeMethods.WM_NCPAINT) {
          WmNcPaint(ref m);
          return;
        }
      }
      base.WndProc(ref m);
    }

    private void WmNcPaint(ref Message m)
    {
      if (!_HasBorders) {
        return;
      }

      IntPtr hDC = NativeMethods.GetWindowDC(m.HWnd);
      using (Graphics g = Graphics.FromHdc(hDC)) {
        // outer border
        if (ContainsFocus) {
          using (Pen pen = new Pen(_BorderColorActive)) {
            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          }
        } else {
          using (Pen pen = new Pen(_BorderColor)) {
            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
          }
        }
        // required since the border is 2px for Fixed3D (which is what TextBox uses by default)
        using (Pen pen = new Pen(BackColor)) {
          g.DrawRectangle(pen, new Rectangle(1, 1, this.Width - 3, this.Height - 3));
        }
      }
      NativeMethods.ReleaseDC(m.HWnd, hDC);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
    }
  }
}
