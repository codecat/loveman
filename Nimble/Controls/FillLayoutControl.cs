using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Nimble.Controls
{
  [Designer(typeof(FillLayoutControlDesigner))]
  public partial class FillLayoutControl : Control
  {
    public float PartScale { get; set; } = 0.25f;
    public int Spacing { get; set; } = 6;

    private List<Control> m_sorted;

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
      m_sorted = null;
      base.OnControlAdded(e);
      DoFillLayout();
    }

    protected override void OnControlRemoved(ControlEventArgs e)
    {
      m_sorted = null;
      base.OnControlRemoved(e);
      DoFillLayout();
    }

    protected override void OnLayout(LayoutEventArgs levent)
    {
      base.OnLayout(levent);
      DoFillLayout();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      DoFillLayout();
    }

    private void DoFillLayout()
    {
      if (DesignMode) {
        return;
      }

      SuspendLayout();

      if (m_sorted == null) {
        m_sorted = new List<Control>();
        foreach (Control ctl in Controls) {
          m_sorted.Add(ctl);
        }
        m_sorted.Sort((a, b) => a.Top < b.Top ? -1 : 1);
      }

      int curY = 0;

      Control lastCtl = null;

      for (int i = 0; i < m_sorted.Count; i++) {
        var ctl = m_sorted[i];
        if (!ctl.Visible) {
          continue;
        }

        ctl.Left = 0;
        ctl.Top = curY;
        ctl.Width = Width;
        ctl.Height = (int)(PartScale * Height);

        curY += ctl.Height + Spacing;

        lastCtl = ctl;
      }

      if (lastCtl != null) {
        lastCtl.Height = Height - lastCtl.Top;
      }

      ResumeLayout();
    }
  }

  public class FillLayoutControlDesigner : ParentControlDesigner
  {
  }
}
