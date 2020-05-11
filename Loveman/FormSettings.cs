using Loveman.Properties;
using Nimble.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loveman
{
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			InitializeComponent();

			textLovePath.Text = Settings.Default.Path_Love;
			textProjectsPath.Text = Settings.Default.Path_Projects;
			textEditorPath.Text = Settings.Default.Path_Editor;
			textSublimeMergePath.Text = Settings.Default.Path_SublimeMerge;

			Interface.InterfaceTheme(this);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Settings.Default.Path_Love = textLovePath.Text;
			Settings.Default.Path_Projects = textProjectsPath.Text;
			Settings.Default.Path_Editor = textEditorPath.Text;
			Settings.Default.Path_SublimeMerge = textSublimeMergePath.Text;
			Settings.Default.Save();

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonBrowseLove_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			fbd.Description = "Navigate to the folder where LOVE is installed.";
			fbd.SelectedPath = textLovePath.Text;
			if (fbd.ShowDialog(this) != DialogResult.OK) {
				return;
			}
			textLovePath.Text = fbd.SelectedPath;
		}

		private void buttonBrowseProjects_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			fbd.Description = "Navigate to the folder where you store LOVE projects.";
			fbd.SelectedPath = textProjectsPath.Text;
			if (fbd.ShowDialog(this) != DialogResult.OK) {
				return;
			}
			textProjectsPath.Text = fbd.SelectedPath;
		}

		private void buttonBrowseEditor_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.Title = "Browse for editor";
			ofd.Filter = "Programs (*.exe)|*.exe|Batch scripts (*.bat)|*.bat|All files (*.*)|*.*";
			if (ofd.ShowDialog(this) != DialogResult.OK) {
				return;
			}
			textEditorPath.Text = ofd.FileName;
		}

		private void buttonBrowseSublimeMerge_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			fbd.Description = "Navigate to the folder where Sublime Merge is.";
			fbd.SelectedPath = textSublimeMergePath.Text;
			if (fbd.ShowDialog(this) != DialogResult.OK) {
				return;
			}
			textSublimeMergePath.Text = fbd.SelectedPath;
		}
	}
}
