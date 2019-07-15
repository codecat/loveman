using Loveman.Properties;
using Nimble.Controls.FlatControls;
using Nimble.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loveman
{
	public partial class FormProject : Form
	{
		private ProjectInfo m_project;

		private FileSystemWatcher m_watcher;
		private List<MoonQueuedItem> m_watchQueue;
		private Timer m_watchTimer;

		private bool m_hasSublimeText;
		private bool m_hasSublimeMerge;

		public FormProject(ProjectInfo project)
		{
			InitializeComponent();

			m_project = project;

			UpdateInfo();
			ShowInfoSave(false);

			m_watcher = new FileSystemWatcher(m_project.GetPath(), "*.moon");
			m_watcher.IncludeSubdirectories = true;
			m_watcher.Created += MoonWatcher_Created;
			m_watcher.Changed += MoonWatcher_Changed;
			m_watcher.Deleted += MoonWatcher_Deleted;
			m_watcher.Renamed += MoonWatcher_Renamed;
			m_watcher.EnableRaisingEvents = true;

			m_watchQueue = new List<MoonQueuedItem>();

			m_watchTimer = new Timer();
			m_watchTimer.Interval = 100;
			m_watchTimer.Tick += WatchTimer_Tick;
			m_watchTimer.Enabled = true;

			if (!CanUseMoonscript()) {
				checkWatchForChanges.Checked = false;
				checkWatchForChanges.AutoCheck = false;
			}

			m_hasSublimeText = (Path.GetFileName(Settings.Default.Path_Editor) == "sublime_text.exe");
			buttonSublime.Visible = m_hasSublimeText;

			m_hasSublimeMerge = (
				Settings.Default.Path_SublimeMerge != "" &&
				File.Exists(Path.Combine(Settings.Default.Path_SublimeMerge, "smerge.exe"))
			);
			buttonSublimeMerge.Visible = m_hasSublimeMerge;

			Interface.InterfaceTheme(this);

			flowButtons.BorderStyle = BorderStyle.None;
		}

		private bool CanUseMoonscript()
		{
			return Settings.Default.Path_Moonscript != "" && Directory.Exists(Settings.Default.Path_Moonscript);
		}

		private void StartGame(bool console)
		{
			var startInfo = new ProcessStartInfo();
			startInfo.FileName = Path.Combine(Settings.Default.Path_Love, console ? "lovec.exe" : "love.exe");
			startInfo.Arguments = m_project.GetPath();
			startInfo.WorkingDirectory = m_project.GetPath();
			Process.Start(startInfo);
		}

		private void UpdateInfo()
		{
			Text = m_project.m_name;

			textProjectName.Text = m_project.m_name;
			textProjectAuthor.Text = m_project.m_author;
			textProjectBundleIdentifier.Text = m_project.m_bundleIdentifier;
		}

		private void ShowInfoSave(bool visible)
		{
			buttonSave.Visible = visible;
			buttonCancel.Visible = visible;
		}

		private void AddMoonscriptLog(string text, string subText, string relPath, Image icon, uint line = 0)
		{
			var fli = new FlatListItem();
			fli.Text = text;
			fli.Tag = new MoonLogLineInfo() {
				RelPath = relPath,
				Line = line
			};
			fli.Image = icon;
			fli.SubText = DateTime.Now.ToString("HH:mm:ss") + " " + subText;
			listChanges.Items.Insert(0, fli);
		}

		private Task<bool> BuildMoonscriptFile(string info, string relPath)
		{
			if (!CanUseMoonscript()) {
				return null;
			}

			var ret = new Task<bool>(() => {
				var startInfo = new ProcessStartInfo();
				startInfo.FileName = Path.Combine(Settings.Default.Path_Moonscript, "moonc.exe");
				startInfo.Arguments = relPath;
				startInfo.WorkingDirectory = m_project.GetPath();
				startInfo.RedirectStandardError = true;
				startInfo.UseShellExecute = false;
				startInfo.CreateNoWindow = true;

				var p = Process.Start(startInfo);
				string errors = p.StandardError.ReadToEnd(); // errors & OK
				int exitCode = p.ExitCode; // 1 = failed, 0 = ok

				var dateFormat = DateTime.Now.ToString("HH:mm:ss");

				Invoke(new Action(() => {
					string text = info + ": " + relPath;

					if (exitCode == 1) {
						var subText = errors.Substring(relPath.Length).Replace("\r", "").Replace("\n", "").Trim();

						uint line = 0;
						var matchLine = Regex.Match(errors, @" \[([0-9]+)\] >>");
						if (matchLine.Success) {
							line = uint.Parse(matchLine.Groups[1].Value);
						}

						AddMoonscriptLog(text, subText, relPath, Resources.cancel, line);
					} else {
						AddMoonscriptLog(text, "OK", relPath, Resources.accept);
					}

					if (listChanges.Items.Count > 100) {
						listChanges.Items.RemoveAt(100);
					}
				}));

				return (exitCode == 0);
			});
			ret.Start();
			return ret;
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			StartGame(false);
		}

		private void buttonStartConsole_Click(object sender, EventArgs e)
		{
			StartGame(true);
		}

		private void buttonFolder_Click(object sender, EventArgs e)
		{
			Process.Start(m_project.GetPath());
		}

		private void textProjectInfo_TextChanged(object sender, EventArgs e)
		{
			ShowInfoSave(true);
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			m_project.m_name = textProjectName.Text;
			m_project.m_author = textProjectAuthor.Text;
			m_project.m_bundleIdentifier = textProjectBundleIdentifier.Text;
			m_project.m_iconFile = textGameIcon.Text;
			m_project.SaveJson();

			UpdateInfo();
			ShowInfoSave(false);

			Program.MainForm.ReloadProjects();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			UpdateInfo();
			ShowInfoSave(false);
		}

		private void checkWatchForChanges_CheckedChanged(object sender, EventArgs e)
		{
			m_watcher.EnableRaisingEvents = checkWatchForChanges.Checked;
		}

		private void HandleQueuedFile(MoonQueuedItem item)
		{
			string relPath = item.FullPath.Substring(m_project.GetPath().Length + 1);

			// If the file doesn't exist, we'll remove the lua file
			if (!File.Exists(item.FullPath)) {
				var luaPath = Path.ChangeExtension(item.FullPath, ".lua");
				if (File.Exists(luaPath)) {
					File.Delete(luaPath);
					Invoke(new Action(() => {
						AddMoonscriptLog("Deleted file: " + relPath, "OK", relPath, Resources.accept);
					}));
				}
				return;
			}

			// The file exists, so we just compile it
			BuildMoonscriptFile(item.Action, relPath);
		}

		private void WatchTimer_Tick(object sender, EventArgs e)
		{
			lock (m_watchQueue) {
				for (int i = m_watchQueue.Count - 1; i >= 0; i--) {
					var item = m_watchQueue[i];
					var delay = (DateTime.Now - item.Time);
					if (delay.TotalSeconds >= 0.5) {
						HandleQueuedFile(item);
						m_watchQueue.RemoveAt(i);
						UpdateMoonQueueText();
					}
				}
			}
		}

		private void UpdateMoonQueueText()
		{
			Invoke(new Action(() => {
				if (m_watchQueue.Count > 0) {
					groupMoonscript.Title = "Moonscript (" + m_watchQueue.Count + " in queue)";
				} else {
					groupMoonscript.Title = "Moonscript";
				}
			}));
		}

		private void MoonWatcher_Queue(string fullPath, string action)
		{
#if DEBUG
			string relPath = fullPath.Substring(m_project.GetPath().Length + 1);
			Console.WriteLine("{0} queued: {1}", action, relPath);
#endif

			lock (m_watchQueue) {
				int existingIndex = m_watchQueue.FindIndex(pair => pair.FullPath == fullPath);
				if (existingIndex != -1) {
					var item = m_watchQueue[existingIndex];
					//item.Action = action; // Don't set action to latest action because we only care about the first
					item.Time = DateTime.Now;
				} else {
					m_watchQueue.Add(new MoonQueuedItem() {
						FullPath = fullPath,
						Action = action,
						Time = DateTime.Now
					});
					UpdateMoonQueueText();
				}
			}
		}

		private void MoonWatcher_Created(object sender, FileSystemEventArgs e)
		{
			MoonWatcher_Queue(e.FullPath, "Created");
		}

		private void MoonWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			MoonWatcher_Queue(e.FullPath, "Changed");
		}

		private void MoonWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
			MoonWatcher_Queue(e.FullPath, "Deleted");
		}

		private void MoonWatcher_Renamed(object sender, RenamedEventArgs e)
		{
			MoonWatcher_Queue(e.FullPath, "Renamed");
			MoonWatcher_Queue(e.OldFullPath, "Renamed");
		}

		private void buttonBuildScripts_Click(object sender, EventArgs e)
		{
			if (!CanUseMoonscript()) {
				MessageBox.Show(this, "Moonscript is not set up yet. Add the directory to where Moonscript is located to the settings dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var files = Directory.GetFiles(m_project.GetPath(), "*.moon", SearchOption.AllDirectories);
			foreach (var file in files) {
				BuildMoonscriptFile("Build all", file.Substring(m_project.GetPath().Length + 1));
			}
		}

		private void listChanges_DoubleClick(object sender, EventArgs e)
		{
			if (listChanges.SelectedItems.Length == 0 || listChanges.SelectedItems[0].Tag == null) {
				return;
			}

			var info = (MoonLogLineInfo)listChanges.SelectedItems[0].Tag;
			var filePath = Path.Combine(m_project.GetPath(), info.RelPath);
			if (!File.Exists(filePath) || !File.Exists(Settings.Default.Path_Editor)) {
				return;
			}

			var args = filePath;
			if (m_hasSublimeText && info.Line > 0) {
				args += ":" + info.Line;
			}

			Process.Start(Settings.Default.Path_Editor, args);
		}

		private void buttonSublime_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default.Path_Editor, m_project.GetPath());
		}

		private void buttonSublimeMerge_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(Path.Combine(m_project.GetPath(), ".git"))) {
#if RELEASE
				try {
#endif
					Process.Start(new ProcessStartInfo("git", "init") {
						WorkingDirectory = m_project.GetPath(),
						WindowStyle = ProcessWindowStyle.Hidden
					}).WaitForExit();
#if RELEASE
				} catch {
					MessageBox.Show(this, "This project is not in source control yet, and \"git\" is not available in %PATH%.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
#endif
			}

			var pathSmerge = Path.Combine(Settings.Default.Path_SublimeMerge, "smerge.exe");
			Process.Start(new ProcessStartInfo(pathSmerge, m_project.GetPath()) {
				WindowStyle = ProcessWindowStyle.Hidden
			});
		}

		private void buttonBuildRelease_Click(object sender, EventArgs e)
		{
			new FormRelease(m_project).ShowDialog(this);
		}
	}
}
