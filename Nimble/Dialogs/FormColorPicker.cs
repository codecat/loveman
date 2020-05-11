using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nimble.Drawing;
using Nimble.Controls.FlatControls;
using Nimble.Extensions;

namespace Nimble.Dialogs
{
  public partial class FormColorPicker : Form
  {
    private bool _ColorChanging = false;
    private int _ColorChangingType = 0;
    private Color _Color = Color.Black;
    public Color Color
    {
      get { return _Color; }
      set
      {
        _Color = value;
        _ColorChanging = true;
        SetFields(_Color);
        UpdatePreview();
        _ColorChanging = false;
      }
    }

    public ColorHSV ColorHSV
    {
      get { return new ColorHSV(Color); }
      set { Color = value.ToColorRGB(); }
    }

    public List<Color> Colors
    {
      get { return colorPickerBox1.Colors; }
      set { colorPickerBox1.Colors = value; }
    }

    public FormColorPicker()
    {
      InitializeComponent();

      Interface.Interface.InterfaceTheme(this);

      panelPreview.HasBorders = false;
      panelPreview.BackColor = _Color;

      InterchangeEvents(scrollR, numR, 1);
      InterchangeEvents(scrollG, numG, 1);
      InterchangeEvents(scrollB, numB, 1);

      InterchangeEvents(scrollH, numH, 2);
      InterchangeEvents(scrollS, numS, 2);
      InterchangeEvents(scrollV, numV, 2);

      InterchangeEvents(scrollA, numA, 3);
    }

    private void InterchangeEvents(FlatScrollbar scroll, FlatNumberBox num, int type)
    {
      scroll.ValueChanged += new EventHandler((o, e) => {
        num.Value = scroll.Value;
      });
      num.ValueChanged += new EventHandler((o, e) => {
        scroll.Value = num.Value;
      });
      switch (type) {
        case 1:
          scroll.ValueChanged += new EventHandler(rgb_changed);
          num.ValueChanged += new EventHandler(rgb_changed);
          break;

        case 2:
          scroll.ValueChanged += new EventHandler(hsv_changed);
          num.ValueChanged += new EventHandler(hsv_changed);
          break;

        case 3:
          scroll.ValueChanged += new EventHandler(alpha_changed);
          num.ValueChanged += new EventHandler(alpha_changed);
          break;
      }
    }

    private void rgb_changed(object sender, EventArgs e)
    {
      if (_ColorChanging) {
        return;
      }

      _ColorChangingType = 1;
      Color = Color.FromArgb(numR.Value, numG.Value, numB.Value);
    }

    private void hsv_changed(object sender, EventArgs e)
    {
      if (_ColorChanging) {
        return;
      }

      ColorHSV hsv = new ColorHSV();
      hsv.Hue = (double)numH.Value;
      hsv.Saturation = (double)numS.Value;
      hsv.Value = (double)numV.Value;

      _ColorChangingType = 2;
      Color = hsv.ToColorRGB();
    }

    private void alpha_changed(object sender, EventArgs e)
    {
      if (_ColorChanging) {
        return;
      }

      _ColorChangingType = 3;
      Color = Color.FromArgb(numA.Value, _Color);
    }

    private void textHex_TextChanged(object sender, EventArgs e)
    {
      if (_ColorChanging) {
        return;
      }

      _ColorChangingType = 4;
      Color = ColorExtensions.FromHexString(textHex.Text);
    }

    private void UpdatePreview()
    {
      panelPreview.BackColor = _Color;
    }

    private void UpdateHex()
    {
      textHex.Text = _Color.ToHexString();
    }

    private void SetFields(Color col)
    {
      int type = _ColorChangingType;

      if (type != 1) {
        numR.Value = scrollR.Value = col.R;
        numG.Value = scrollG.Value = col.G;
        numB.Value = scrollB.Value = col.B;
      }

      if (type != 2) {
        ColorHSV hsv = new ColorHSV(col);
        numH.Value = scrollH.Value = (int)hsv.Hue;
        numS.Value = scrollS.Value = (int)hsv.Saturation;
        numV.Value = scrollV.Value = (int)hsv.Value;
      }

      if (type != 3) {
        numA.Value = scrollA.Value = col.A;
      }

      if (type != 4) {
        UpdateHex();
      }

      if (type != 5) {
        colorWheel1.Color = new ColorHSV(col);
      }
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void colorPickerBox1_Click(object sender, Color color)
    {
      _ColorChangingType = 0;
      Color = color;
    }

    private void colorWheel1_OnColorChanged(object sender, EventArgs e)
    {
      _ColorChangingType = 5;
      Color = colorWheel1.Color.ToColorRGB();
    }
  }
}
