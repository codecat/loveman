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
using Loveman.Properties;
using Nimble.Interface;

namespace Loveman
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();

			// If we don't have a LOVE path set, check if we might have it installed already
			if (Settings.Default.Path_Love == "") {
				// 64 bit
				var pathLove = @"C:\Program Files\LOVE";
				if (Directory.Exists(pathLove)) {
					Settings.Default.Path_Love = pathLove;
					Settings.Default.Save();
				} else {
					// 32 bit
					pathLove = @"C:\Program Files (x86)\LOVE";
					if (Directory.Exists(pathLove)) {
						Settings.Default.Path_Love = pathLove;
						Settings.Default.Save();
					} else {
						// :(
						MessageBox.Show(this, "We couldn't automatically detect an installation of LOVE. Make sure you set the path in the settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}

			// If we don't have a projects path set, we'll just use the documents folder
			if (Settings.Default.Path_Projects == "") {
				Settings.Default.Path_Projects = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LOVE Projects";
				Settings.Default.Save();
			}

			ReloadSettings();

			Interface.InterfaceTheme(this);
		}

		private void ReloadSettings()
		{
			// If the projects directory doesn't exist yet, we create it
			if (!Directory.Exists(Settings.Default.Path_Projects)) {
				Directory.CreateDirectory(Settings.Default.Path_Projects);
			}

			// Reload list of projects
			ReloadProjects();
		}

		public void ReloadProjects()
		{
			listProjects.Clear();

			var dirs = Directory.GetDirectories(Settings.Default.Path_Projects);
			foreach (var dir in dirs) {
				var project = new ProjectInfo(dir);

				var fli = listProjects.Items.Add(project.m_name);

				var subtext = "";
				if (project.HasMoonscript()) {
					subtext = "A Moonscript project by " + project.m_author;
				} else {
					subtext = "A Lua project by " + project.m_author;
				}
				fli.SubText = subtext;

				fli.Image = project.HasMoonscript() ? Resources.moon16 : Resources.love16;
				fli.Tag = project;
			}
		}

		private void buttonSettings_Click(object sender, EventArgs e)
		{
			if (new FormSettings().ShowDialog(this) != DialogResult.OK) {
				return;
			}

			ReloadSettings();
		}

		private void listProjects_DoubleClick(object sender, EventArgs e)
		{
			if (listProjects.SelectedItem == null) {
				return;
			}
			new FormProject((ProjectInfo)listProjects.SelectedItem.Tag).Show(this);
		}

		private void buttonNewProject_Click(object sender, EventArgs e)
		{
			new FormNewProject().ShowDialog(this);
		}
	}
}
