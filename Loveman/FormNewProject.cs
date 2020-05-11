using Loveman.Properties;
using Nimble.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loveman
{
	public partial class FormNewProject : Form
	{
		public FormNewProject()
		{
			InitializeComponent();

			radioLove2D.Enabled = (Settings.Default.Path_Love != "" && Directory.Exists(Settings.Default.Path_Love));
			radioLovr.Enabled = (Settings.Default.Path_Lovr != "" && Directory.Exists(Settings.Default.Path_Lovr));

			buttonOK.Enabled = (radioLove2D.Enabled || radioLovr.Enabled);

			Interface.InterfaceTheme(this);
		}

		private string GetProperFolderName(string path)
		{
			foreach (char c in Path.GetInvalidPathChars()) {
				path = path.Replace(c, '_');
			}
			path = path.Replace('/', '_');
			path = path.Replace('\\', '_');
			return path;
		}

		private string GetProperFilename(string path)
		{
			foreach (char c in Path.GetInvalidFileNameChars()) {
				path = path.Replace(c, '_');
			}
			return path;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (textProjectName.Text == "") {
				MessageBox.Show(this, "You have to enter a project name!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var projectId = GetProperFolderName(textProjectName.Text);
			var projectPath = Path.Combine(Settings.Default.Path_Projects, projectId);

			if (Directory.Exists(projectPath)) {
				MessageBox.Show(this, "The foler \"" + projectPath + "\" already exists. Delete or move it to create a project with this name.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Directory.CreateDirectory(projectPath);

			var project = new ProjectInfo(projectPath);
			project.m_name = textProjectName.Text;
			project.m_author = textProjectAuthor.Text;
			project.m_bundleIdentifier = textProjectBundleIdentifier.Text;
			if (radioLove2D.Checked) {
				project.m_type = ProjectInfo.ProjectType.Love2D;
			} else if (radioLovr.Checked) {
				project.m_type = ProjectInfo.ProjectType.Lovr;
			}
			project.SaveJson();

			Program.MainForm.ReloadProjects();

			new FormProject(project).Show(Program.MainForm);
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textProjectName_TextChanged(object sender, EventArgs e)
		{
			if (textProjectName.Text == "") {
				labelCreatedPath.Text = "...";
				return;
			}

			var projectId = GetProperFolderName(textProjectName.Text);
			var projectPath = Path.Combine(Settings.Default.Path_Projects, projectId);

			labelCreatedPath.Text = projectPath;
		}
	}
}
