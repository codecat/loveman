using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Nimble.Controls
{
  public class ExtendedPanel : Panel
  {
    private bool _EnableScrollToControl = true;
    [Description("Whether to automatically scroll to fit the clicked control in view")]
    [Category("Behavior")]
    public bool EnableScrollToControl
    {
      get { return _EnableScrollToControl; }
      set { _EnableScrollToControl = value; }
    }

    private bool _ClickFocusesSelf = true;
    [Description("Whether clicking an empty space in the panel focuses itself (useful for scrolling)")]
    [Category("Behavior")]
    public bool ClickFocusesSelf
    {
      get { return _ClickFocusesSelf; }
      set { _ClickFocusesSelf = value; }
    }

    public List<Control> IgnoreScrollControls = new List<Control>();

    private Color _BorderColor = SystemColors.WindowFrame;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private bool _HasBorders = false;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    protected override Point ScrollToControl(Control activeControl)
    {
      if (EnableScrollToControl) {
        return base.ScrollToControl(activeControl);
      } else {
        return this.AutoScrollPosition;
      }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      foreach (Control ctl in IgnoreScrollControls) {
        if (ctl.ContainsFocus) {
          return;
        }
      }
      base.OnMouseWheel(e);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      if (ClickFocusesSelf) {
        this.Focus();
      }
      base.OnMouseClick(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (_HasBorders) {
        ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width, this.Height), _BorderColor, ButtonBorderStyle.Solid);
      }
    }

    protected override void OnResize(EventArgs eventargs)
    {
      base.OnResize(eventargs);
      Refresh();
    }
  }
}
