using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Nimble.Controls.FlatControls;
using Nimble.Controls;
using Nimble.Extensions;
using Nimble.Drawing;
using System.IO;
using Nimble.Utils;
using System.Drawing.Imaging;

namespace Nimble.Interface
{
  public static class Interface
  {
    public static System.Configuration.ApplicationSettingsBase SettingsObject { get; set; }
    public static Action<Control> CustomCallback { get; set; }
    public static string Namespace { get; set; }

    public static bool bLightTheme { get; private set; }

    public static double fdeltaColorMouseOver { get; private set; }
    public static double fdeltaColorMouseDown { get; private set; }

    public static Color colBackground { get; private set; }
    public static Color colForeground { get; private set; }
    public static Color colSelection { get; private set; }
    public static Color colSelectionText { get; private set; }
    public static Color colMouseOver { get; private set; }
    public static Color colMouseDown { get; private set; }
    public static Color colAccent { get; private set; }
    public static Color colBorder { get; private set; }

    public static string strFont { get; private set; }

    public static bool bBorders { get; private set; }
    public static BorderStyle borderStyle { get; private set; }

    public static void InterfaceTheme(Form form, bool suspendDrawing = false)
    {
      if (suspendDrawing) {
        form.SuspendDrawing();
        InterfaceThemeControl(form);
        form.ResumeDrawing();
      } else {
        InterfaceThemeControl(form);
      }
    }

    public static dynamic DefaultSetting(string strKey)
    {
      switch (strKey) {
        case "ifc_bLightTheme": return false;
        case "ifc_colBackground": return Color.FromArgb(63, 63, 63);
        case "ifc_colText": return Color.FromArgb(220, 220, 204);
        case "ifc_colSelection": return Color.FromArgb(87, 91, 96);
        case "ifc_colSelectionText": return Color.FromArgb(220, 220, 204);
        case "ifc_colAccent": return Color.FromArgb(130, 134, 255);
        case "ifc_colBorder": return Color.FromArgb(90, 90, 90);
        case "ifc_bBorders": return true;
        case "ifc_strImages": return "Default";
        case "ifc_fdeltaColorMouseOver": return 0.2f;
        case "ifc_fdeltaColorMouseDown": return -0.2f;
        case "ifc_fdeltaColorScrollbarFill": return 0.075f;
        case "ifc_fdeltaColorScrollbarHandle": return -0.1f;
        case "ifc_fdeltaColorScrollbarHandleGrip": return -0.15f;
        case "ifc_fdeltaColorScrollbarGuideline": return 0.4f;
        case "ifc_fdeltaColorListSubtext": return -0.2f;
        case "ifc_fScrollbarHandleMargin": return 0.0f;
        case "ifc_iScrollbarHandleCount": return 1f;
        case "ifc_fListSubtextScale": return 0.85f;
        case "ifc_strFont": return SystemFonts.DefaultFont.Name;
      }
      throw new Exception("Unknown default for key: '" + strKey + "'");
    }

    public static dynamic GetSetting(string strKey)
    {
      if (SettingsObject != null) {
        try {
          return SettingsObject[strKey];
        } catch { }
      }
      return DefaultSetting(strKey);
    }

    public static void InterfaceThemeControl(Control root)
    {
      bLightTheme = GetSetting("ifc_bLightTheme");

      fdeltaColorMouseOver = GetSetting("ifc_fdeltaColorMouseOver");
      fdeltaColorMouseDown = GetSetting("ifc_fdeltaColorMouseDown");

      colBackground = GetSetting("ifc_colBackground");
      colForeground = GetSetting("ifc_colText");
      colSelection = GetSetting("ifc_colSelection");
      colSelectionText = GetSetting("ifc_colSelectionText");
      colMouseOver = ColorHSV.ModifyValue(colBackground, fdeltaColorMouseOver, !bLightTheme);
      colMouseDown = ColorHSV.ModifyValue(colBackground, fdeltaColorMouseDown, !bLightTheme);
      colAccent = GetSetting("ifc_colAccent");
      colBorder = GetSetting("ifc_colBorder");

      strFont = GetSetting("ifc_strFont");

      bBorders = GetSetting("ifc_bBorders");
      borderStyle = bBorders ? BorderStyle.FixedSingle : BorderStyle.None;

      root.BackColor = colBackground;

      if (root.ForeColor != Color.OrangeRed && root.ForeColor != colAccent) {
        root.ForeColor = colForeground;
      }

      if (root.Font.FontFamily.Name != "Webdings" && !(root is Form) && !root.HasChildren) {
        try {
          //TODO: This is really slow, can we speed it up somehow?
          root.Font = new Font(new FontFamily(strFont), root.Font.Size, root.Font.Style);
        } catch { }
      }

      if (root is ExtendedPanel || typeof(ExtendedPanel).IsAssignableFrom(root.GetType())) {
        ExtendedPanel panel = (ExtendedPanel)root;
        panel.BorderStyle = BorderStyle.None;
        panel.BorderColor = colBorder;
        if (panel.HasBorders && panel.AutoScroll && panel.Name != "container") {
          // special case: we have to wrap this panel inside of another panel for the border to not mess up when scrolling
          ExtendedPanel container = new ExtendedPanel();
          container.Name = "container";
          container.Left = panel.Left;
          container.Top = panel.Top;
          container.Width = panel.Width;
          container.Height = panel.Height;
          container.BackColor = panel.BackColor;
          container.ForeColor = panel.ForeColor;
          container.BorderStyle = panel.BorderStyle;
          container.HasBorders = panel.HasBorders;
          container.BorderColor = panel.BorderColor;
          container.Anchor = panel.Anchor;
          Control parent = panel.Parent;
          container.Controls.Add(panel);
          parent.Controls.Add(container);
          panel.HasBorders = false;
          panel.Location = new Point(1, 1);
          panel.Size = new Size(container.Width - 2, container.Height - 2);
          panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }
      } else if (root is Panel) {
        //TODO: Move these to some configurable array instead of hardcoding them in Nimble.dll...
        if (root.Name != "panelTopBar" && root.Name != "panelFormatting") {
          Panel panel = (Panel)root;
          panel.BorderStyle = borderStyle;
        }
      }

      if (root is FlatGroupBox) {
        FlatGroupBox box = (FlatGroupBox)root;
        box.BorderColor = colBorder;
        box.HasBorders = bBorders;
      }

      if (root is FlatButton) {
        FlatButton btn = (FlatButton)root;
        btn.BackColorOver = colMouseOver;
        btn.BackColorDown = colMouseDown;
        btn.BorderColor = colBorder;
        btn.HasBorder = bBorders;
      }

      if (root is ExtendedTextBox) {
        ExtendedTextBox text = (ExtendedTextBox)root;
        text.HasBorders = bBorders;
        text.BorderColor = colBorder;
        text.BorderColorActive = colBorder;
      }

      if (root is DrawBox) {
        DrawBox db = (DrawBox)root;
        db.HasBorders = bBorders;
        db.BorderColor = colBorder;
        db.ColorPrimary = colAccent;
        db.ColorSecondary = colBorder;
      }

      if (root is DraggablePictureBox) {
        DraggablePictureBox dpb = (DraggablePictureBox)root;
        dpb.BorderStyle = BorderStyle.None;
        dpb.HasBorders = bBorders;
        dpb.BorderColor = colBorder;
      }

      if (root is FlatScrollbar) {
        FlatScrollbar scrollbar = (FlatScrollbar)root;
        scrollbar.BorderColor = bBorders ? colBorder : Color.Empty;
        scrollbar.FillColor = ColorHSV.ModifyValue(colBackground, GetSetting("ifc_fdeltaColorScrollbarFill"), !bLightTheme);
        scrollbar.HandleMargin = GetSetting("ifc_fScrollbarHandleMargin");
        scrollbar.HandleColor = ColorHSV.ModifyValue(colBackground, GetSetting("ifc_fdeltaColorScrollbarHandle"), !bLightTheme);
        scrollbar.HandleGripColor = ColorHSV.ModifyValue(colBackground, GetSetting("ifc_fdeltaColorScrollbarHandleGrip"), !bLightTheme);
        scrollbar.HandleGripCount = GetSetting("ifc_iScrollbarHandleCount");
        scrollbar.GuidelineColor = ColorHSV.ModifyValue(colBackground, GetSetting("ifc_fdeltaColorScrollbarGuideline"), !bLightTheme);
      }

      if (root is FlatList) {
        FlatList list = (FlatList)root;
        list.BorderColor = bBorders ? colBorder : Color.Empty;
        list.HoverColor = colMouseOver;
        list.SelectionColor = colSelection;
        list.SelectionTextColor = colSelectionText;
        list.BorderStyle = borderStyle;
        list.ForeColorSub = ColorHSV.ModifyValue(colForeground, GetSetting("ifc_fdeltaColorListSubtext"), !bLightTheme);
        list.FontSub = new Font(list.Font.FontFamily, list.Font.Size * GetSetting("ifc_fListSubtextScale"));
      }

      if (root is FlatArrowContainer) {
        FlatArrowContainer fac = (FlatArrowContainer)root;
        fac.BorderColor = bBorders ? colBorder : Color.Empty;
      }

      if (root is FlatNumberBox) {
        FlatNumberBox numbox = (FlatNumberBox)root;
        numbox.ButtonBackColor = colBackground;
        numbox.ButtonBackColorDown = colMouseDown;
        numbox.ButtonBackColorOver = colMouseOver;
        numbox.BorderColor = colBorder;
        //numbox.ButtonsVertical = false; //TODO: Make this a setting
      }

      if (root is ExtendedComboBox) {
        ExtendedComboBox combo = (ExtendedComboBox)root;
        combo.FlatStyle = FlatStyle.Popup;
        combo.HasBorders = bBorders;
        combo.BorderColor = colBorder;
        combo.BorderColorActive = colBorder;
        combo.BorderColorDisabled = colBorder;
      }

      if (root is DraggableGraph) {
        DraggableGraph graph = (DraggableGraph)root;
        graph.DotColor = colAccent;
        graph.LineColor = ColorHSV.ModifyValue(colAccent, 0.25, !bLightTheme);
        graph.BorderColor = colBorder;
      }

      CustomCallback?.Invoke(root);

#if DEBUG
      if (root.GetType() == typeof(TextBox) ||
          root.GetType() == typeof(ComboBox) ||
          root.GetType() == typeof(TreeView)) {
        System.Diagnostics.Debug.Assert(false, "Generic WinForms control of type '" + root.GetType().Name + "' found: " + root.Name + " - can you replace it with its (fixed and better working) extended version?");
      }
      if (root is ListBox ||
          root is ListView ||
          root is NumericUpDown ||
          root is Button) {
        System.Diagnostics.Debug.Assert(false, "Generic WinForms control of type '" + root.GetType().Name + "' found: " + root.Name + " - can you replace it with a flat control?");
      }
#endif

      // ignore if this is in a different namespace
      //TODO: ScintillaNET is caught on this, we should replace the inline find/replace thing with a custom one!
      string ns = root.GetType().Namespace;
      if (ns == "System.Windows.Forms" || ns.StartsWith("Nimble.") || (Namespace == null || ns.StartsWith(Namespace))) {
        foreach (Control ctl in root.Controls) {
          InterfaceThemeControl(ctl);
        }
      }
    }

    private static Dictionary<string, Image> ImageCache = new Dictionary<string, Image>();

    public static void ClearImageCache()
    {
      ImageCache.Clear();
    }

    public static Image GetImage(string strFilename, bool skipCache = false)
    {
      Image ret = null;

      string strKey = "Themes/" + GetSetting("ifc_strImages") + "/" + strFilename;
      if (!skipCache && ImageCache.ContainsKey(strKey)) {
        ret = ImageCache[strKey];
      } else {
        if (!File.Exists(strKey)) {
          strKey = "Themes/Default/" + strFilename;
        }
        try {
          using (Stream stream = File.OpenRead(strKey)) {
            using (Image img = Image.FromStream(stream)) {
              ret = img.CloneImage();
            }
          }
          ImageCache.Add(strKey, ret);
        } catch {
          Bitmap bmp = new Bitmap(100, 100);
          using (Graphics g = Graphics.FromImage(bmp)) {
            g.Clear(Color.Fuchsia);
            g.DrawString("Error", SystemFonts.DefaultFont, Brushes.Black, new PointF(3, 3));
          }
          ret = bmp;
        }
      }

      return ret;
    }

    public static Image GetAbsoluteImage(string strFilename, bool skipCache = false)
    {
      Image ret = null;

      if (!skipCache && ImageCache.ContainsKey(strFilename)) {
        ret = ImageCache[strFilename];
      } else {
        try {
          using (Stream stream = File.OpenRead(strFilename)) {
            using (Image img = Image.FromStream(stream)) {
              ret = img.CloneImage();
            }
          }
          ImageCache.Add(strFilename, ret);
        } catch {
          Bitmap bmp = new Bitmap(100, 100);
          using (Graphics g = Graphics.FromImage(bmp)) {
            g.Clear(Color.Fuchsia);
            g.DrawString("Error", SystemFonts.DefaultFont, Brushes.Black, new PointF(3, 3));
          }
          ret = bmp;
        }
      }

      return ret;
    }
  }
}
