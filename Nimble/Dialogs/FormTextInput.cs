using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nimble.Interface;

namespace Nimble.Dialogs
{
  public partial class TextInputDialog : Form
  {
    public string UserInput { get; set; }

    public TextInputDialog(string strPrompt, string strDefault = "")
    {
      InitializeComponent();

      Interface.Interface.InterfaceTheme(this);

      DialogResult = DialogResult.Cancel;

      labelText.Text = strPrompt;
      textInput.Text = strDefault;

      textInput.Focus();
      textInput.SelectAll();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter) {
        buttonOK.PerformClick();
      }

      if (keyData == Keys.Escape) {
        buttonCancel.PerformClick();
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      UserInput = textInput.Text;
      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
