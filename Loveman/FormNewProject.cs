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
using System.Threading;
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

			AddFeature(new Features.MainLua());
			AddFeature(new Features.ConfLua());
			AddFeature(new Features.Git());
			AddFeature(new Features.VSCodeConfig());
			AddFeature(new Features.JonClass());
			AddFeature(new Features.LeanClass());
			AddFeature(new Features.HUMP());
			AddFeature(new Features.HUMPFork());
			AddFeature(new Features.Knife());
			AddFeature(new Features.TinyEcs());
			AddFeature(new Features.Lume());
			AddFeature(new Features.Lurker());

			Interface.InterfaceTheme(this);
		}

		private void AddFeature(IFeature feature)
		{
			var fli = listFeatures.Items.Add(feature.GetName());
			fli.Tag = feature;
			feature.ConfigureItem(fli);
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
				project.m_type = LoveType.Love2D;
			} else if (radioLovr.Checked) {
				project.m_type = LoveType.Lovr;
			}
			project.SaveJson();

			var numFeatures = 0;
			foreach (var item in listFeatures.Items) {
				if (item.Checked) {
					numFeatures++;
				}
			}

			if (numFeatures > 0) {
				var progressWindow = new FormProgress();
				progressWindow.Text = "Creating project " + textProjectName.Text;

				var thr = new Thread(new ThreadStart(() => {
					progressWindow.WaitUntilCreated();

					var currentFeature = 0;
					foreach (var item in listFeatures.Items) {
						if (!item.Checked) {
							continue;
						}

						var feature = (item.Tag as IFeature);

						progressWindow.SetStatus(currentFeature / (double)numFeatures, "Applying feature: " + feature.GetName());

						try {
							feature.ApplyFeature(project);
						} catch (Exception ex) {
							Invoke(new Action(() => {
								MessageBox.Show(this, "Failed to apply feature: " + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}));
						}

						currentFeature++;
					}

					progressWindow.Finished();
				}));

				thr.IsBackground = true;
				thr.Start();

				progressWindow.ShowDialog(this);

				thr.Join();
			}

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
