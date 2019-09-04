using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Loveman.Properties;
using Nimble.Interface;
using Nimble.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loveman
{
	public partial class FormRelease : Form
	{
		const string URL_LOVE_DOWNLOADS = "https://api.bitbucket.org/2.0/repositories/rude/love/downloads/";

		private ProjectInfo m_project;
		private LoveVersion m_loveVersion;

		private List<Task> m_tasks;

		public FormRelease(ProjectInfo projectInfo)
		{
			InitializeComponent();

			m_project = projectInfo;

			m_loveVersion = new LoveVersion();
			m_loveVersion.Version = LoveVersion.GetInstalledVersion();

			m_tasks = new List<Task>();

			if (File.Exists(GetVersionPath("win32"))) { m_loveVersion.Download_Win32 = ".."; }
			if (File.Exists(GetVersionPath("win64"))) { m_loveVersion.Download_Win64 = ".."; }
			if (File.Exists(GetVersionPath("macos"))) { m_loveVersion.Download_MacOS = ".."; }

			if (!m_loveVersion.HasAllDownloads()) {
				labelStatus.Text = "Finding version downloads for LOVE " + m_loveVersion.Version + "...";

				var wc = new WebClient();
				wc.DownloadStringCompleted += (o, e) => {
					if (e.Error != null) {
						MessageBox.Show(this, "There was a problem fetching the Love2D downloads list from Bitbucket: " + e.Error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						Close();
						return;
					}
					var obj = (Hashtable)Json.JsonDecode(e.Result);

					var arrValues = (ArrayList)obj["values"];
					foreach (Hashtable value in arrValues) {
						var filename = (string)value["name"];
						if (filename.StartsWith("liblove")) {
							continue;
						}

						var matchVersion = Regex.Match(filename, @"[\-_]([0-9][0-9a-z\.~]+)[\-_]([^\.]+)");
						if (!matchVersion.Success) {
							continue;
						}

						var version = matchVersion.Groups[1].Value;
						var platform = matchVersion.Groups[2].Value;
						var extension = Path.GetExtension(filename);

						if (version != m_loveVersion.Version) {
							continue;
						}

#if DEBUG
						Console.WriteLine("Possible version: {0} (platform {1})", filename, platform);
#endif

						var url = (string)((dynamic)value["links"])["self"]["href"];

						if ((platform == "win64" || platform == "win-x64") && extension == ".zip") {
							m_loveVersion.Download_Win64 = url;
						} else if ((platform == "win32" || platform == "win-x86") && extension == ".zip") {
							m_loveVersion.Download_Win32 = url;
						} else if ((platform == "macos" || platform == "macosx-ub") && extension == ".zip") {
							m_loveVersion.Download_MacOS = url;
						}
					}

					if (obj.ContainsKey("next") && !m_loveVersion.HasAllDownloads()) {
						wc.DownloadStringAsync(new Uri((string)obj["next"]));
						FoundVersions(false);
					} else {
						FoundVersions(true);
					}
				};
				wc.Headers[HttpRequestHeader.UserAgent] = "Loveman / nimble.tools";
				wc.DownloadStringAsync(new Uri(URL_LOVE_DOWNLOADS));
			}

			Interface.InterfaceTheme(this);
		}

		private void SetPlatformCheckbox(bool searchDone, string name, string url, string localPath, CheckBox check)
		{
			if (url == "") {
				check.AutoCheck = false;
				check.Checked = false;
				check.Enabled = false;
				if (searchDone) {
					check.Text = name + " (No download found)";
				}
				return;
			}

			check.AutoCheck = true;
			check.Text = name;
			check.Enabled = true;

			if (!File.Exists(localPath)) {
				check.Text += " (Requires download)";
			}
		}

		private string GetVersionPath(string platform)
		{
			if (!Directory.Exists("LoveVersions")) {
				Directory.CreateDirectory("LoveVersions");
			}
			return "LoveVersions/" + m_loveVersion.Version + "_" + platform + ".bin";
		}

		private void DownloadVersion(string url, string path)
		{
			Invoke(new Action(() => labelBuildStatus.Text = "Downloading " + Path.GetFileName(url)));

			var wc = new WebClient();
			wc.Headers[HttpRequestHeader.UserAgent] = "Loveman / nimble.tools";
			wc.DownloadProgressChanged += (o, e) => {
				Invoke(new Action(() => progress.Value = e.ProgressPercentage));
			};
			wc.DownloadFile(url, path);
		}

		private void BeginLoveBuild()
		{
			m_tasks.Add(new Task(() => {
				Invoke(new Action(() => labelBuildStatus.Text = "Building .love file"));

				var projectPath = m_project.GetPath();
				var ignoreFilePath = Path.Combine(projectPath, ".lovemanignore");
				var releasePath = Path.Combine(projectPath, "Release");
				var loveFilePath = Path.Combine(releasePath, "Game.love");

				// Create Release folder if it doesn't exist yet
				if (!Directory.Exists(releasePath)) {
					Directory.CreateDirectory(releasePath);
				}

				// Delete any existing .love file if it exists
				if (File.Exists(loveFilePath)) {
					File.Delete(loveFilePath);
				}

				// Load .lovemanignore file
				var ignoredPaths = new List<string>();
				if (File.Exists(ignoreFilePath)) {
					using (var fs = File.OpenRead(ignoreFilePath)) {
						using (var reader = new StreamReader(fs)) {
							while (!reader.EndOfStream) {
								string line = reader.ReadLine().Trim();
								int commentIndex = line.IndexOf('#');
								if (commentIndex != -1) {
									line = line.Substring(0, commentIndex);
								}
								line = line.Trim();
								if (line == "") {
									continue;
								}
								ignoredPaths.Add(line.Replace(".", "\\.").Replace("*", ".*"));
							}
						}
					}
				}

				// Create zip
				using (var fs = File.Create(loveFilePath)) {
					using (var zip = new ZipArchive(fs, ZipArchiveMode.Create)) {
						// Find all files
						var files = Directory.GetFiles(projectPath, "*", SearchOption.AllDirectories);
						foreach (var file in files) {
							var relPath = file.Substring(projectPath.Length + 1);

							// Filter out files we don't want to distribute
							if (relPath.StartsWith("Release\\")) { continue; }
							if (relPath.StartsWith(".git\\")) { continue; }
							if (Path.GetExtension(relPath) == ".moon") { continue; }
							if (relPath.EndsWith(".gitignore")) { continue; }
							if (relPath == "loveman.json") { continue; }
							if (relPath == "LovemanIcon.png") { continue; }
							if (relPath == ".lovemanignore") { continue; }

							// Filter out files from .lovemanignore file
							bool filterPattern = false;
							foreach (var pattern in ignoredPaths) {
								if (Regex.Match(relPath, pattern).Success) {
									filterPattern = true;
									break;
								}
							}
							if (filterPattern) {
								continue;
							}

							// Write file to zip
							using (var ffs = File.OpenRead(file)) {
								var newEntry = zip.CreateEntry(relPath.Replace('\\', '/'));
								using (var entryStream = newEntry.Open()) {
									var buffer = new byte[1024];
									while (true) {
										int bytesRead = ffs.Read(buffer, 0, buffer.Length);
										if (bytesRead > 0) {
											entryStream.Write(buffer, 0, bytesRead);
										}
										if (bytesRead < buffer.Length) {
											break;
										}
									}
								}
							}

						}
					}
				}
			}));
		}

		private void BeginBuild(string platform, string downloadUrl)
		{
			Invoke(new Action(() => labelBuildStatus.Text = "Preparing " + platform + " build"));

			var versionPath = GetVersionPath(platform);

			var projectPath = m_project.GetPath();
			var releasePath = Path.Combine(projectPath, "Release/" + platform);

			// Delete existing release platform folder if it exists
			if (Directory.Exists(releasePath)) {
				Directory.Delete(releasePath, true);
			}
			Directory.CreateDirectory(releasePath);

			// If the version for this platform hasn't been downloaded yet, do that now
			if (!File.Exists(versionPath)) {
				DownloadVersion(downloadUrl, versionPath);
			}
		}

		private void ExtractZipEntry(ZipArchiveEntry entry, string folder)
		{
			Invoke(new Action(() => labelBuildStatus.Text = "Unzipping " + entry.FullName));

			var extractPath = Path.Combine(folder, entry.FullName);
			if (extractPath.EndsWith("/") || extractPath.EndsWith("\\")) {
				if (!Directory.Exists(extractPath)) {
					Directory.CreateDirectory(extractPath);
				}
				return;
			}

			using (var stream = entry.Open()) {
				using (var writer = File.Create(extractPath)) {
					var buffer = new byte[1024];
					while (true) {
						int bytesRead = stream.Read(buffer, 0, buffer.Length);
						if (bytesRead > 0) {
							writer.Write(buffer, 0, bytesRead);
						}
						if (bytesRead < buffer.Length) {
							break;
						}
					}
				}
			}
		}

		private string EnsureValidFilename(string filename)
		{
			return Path.GetInvalidFileNameChars().Aggregate(filename, (current, c) => current.Replace(c, '_'));
		}

		private void WriteIconsToWindowsExe(string exePath, string imagePath)
		{
			IntPtr hUpdate = Native.BeginUpdateResource(exePath, false);
			if (hUpdate == IntPtr.Zero) {
				return;
			}

			try {
				using (var bmpSource = new Bitmap(imagePath)) {
					var sizes = new int[] { 16, 32, 48, 64, 128, 256 };
					for (int i = 0; i < 6; i++) {
						var size = sizes[i];
						using (var bmp = new Bitmap(size, size)) {
							using (var g = Graphics.FromImage(bmp)) {
								g.InterpolationMode = InterpolationMode.High;
								g.DrawImage(bmpSource, new Rectangle(0, 0, size, size));
							}

							var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Png);
							var bytes = ms.ToArray();
							ms.Dispose();

							var mBuffer = Marshal.AllocHGlobal(bytes.Length);
							Marshal.Copy(bytes, 0, mBuffer, bytes.Length);
							Native.UpdateResource(hUpdate, new IntPtr(3) /* RC_ICON */, new IntPtr(i + 1), 1033 /* Neutral */, mBuffer, (uint)bytes.Length);
							Marshal.FreeHGlobal(mBuffer);
						}
					}
				}
			} catch { }

			Native.EndUpdateResource(hUpdate, false);
		}

		private void BeginWindowsBuild(string platform, string downloadUrl)
		{
			m_tasks.Add(new Task(() => {
				BeginBuild(platform, downloadUrl);

				var versionPath = GetVersionPath(platform);

				var projectPath = m_project.GetPath();
				var releasePath = Path.Combine(projectPath, "Release/" + platform);

				Invoke(new Action(() => labelBuildStatus.Text = "Unzipping " + platform + " package"));

				string loveExePath = "";

				// Unzip all necessary files into the release folder
				using (var fs = File.OpenRead(versionPath)) {
					using (var zip = new ZipArchive(fs, ZipArchiveMode.Read)) {
						foreach (var entry in zip.Entries) {
							var path = Path.GetDirectoryName(entry.FullName);
							if (entry.Name == "") {
								path = entry.FullName;
							}

							if (path != "") {
								var newDirectory = Path.Combine(releasePath, path);
								if (!Directory.Exists(newDirectory)) {
									Directory.CreateDirectory(newDirectory);
								}
							}

							if (entry.Name == "" || entry.Name == "lovec.exe" || (!entry.Name.EndsWith(".dll") && !entry.Name.EndsWith(".exe"))) {
								continue;
							}

							if (entry.Name == "love.exe") {
								loveExePath = Path.Combine(releasePath, entry.FullName);
							}

							ExtractZipEntry(entry, releasePath);
						}
					}
				}

				// Edit the icon resource in the exe
				if (m_project.m_iconFile != "") {
					var iconPath = Path.Combine(m_project.GetPath(), m_project.m_iconFile);
					if (File.Exists(iconPath)) {
						WriteIconsToWindowsExe(loveExePath, iconPath);
					}
				}

				// Append the .love file to the exe
				var loveFilePath = Path.Combine(projectPath, "Release/Game.love");

				using (var writer = File.OpenWrite(loveExePath)) {
					writer.Seek(0, SeekOrigin.End);

					using (var reader = File.OpenRead(loveFilePath)) {
						var buffer = new byte[1024];
						int bytesRead = 0;

						while (true) {
							bytesRead = reader.Read(buffer, 0, buffer.Length);
							if (bytesRead > 0) {
								writer.Write(buffer, 0, bytesRead);
							}
							if (bytesRead != buffer.Length) {
								break;
							}
						}
					}
				}

				// Rename the exe
				var newExeFilename = EnsureValidFilename(m_project.m_name + ".exe");
				var newExePath = Path.Combine(Path.GetDirectoryName(loveExePath), newExeFilename);
				File.Move(loveExePath, newExePath);
			}));
		}

		private void BeginMacOSBuild(string platform, string downloadUrl)
		{
			m_tasks.Add(new Task(() => {
				BeginBuild(platform, downloadUrl);

				// Pick a new .app name
				var newAppName = EnsureValidFilename(m_project.m_name + ".app");

				// Get some paths
				var versionPath = GetVersionPath(platform);

				var projectPath = m_project.GetPath();
				var releasePath = Path.Combine(projectPath, "Release/" + platform);

				Invoke(new Action(() => labelBuildStatus.Text = "Unzipping " + platform + " package"));

				// Unzip all necessary files into the release folder
				using (var fs = File.OpenRead(versionPath)) {
					using (var zip = new ZipArchive(fs, ZipArchiveMode.Read)) {
						foreach (var entry in zip.Entries) {
							var path = Path.GetDirectoryName(entry.FullName);
							if (entry.Name == "") {
								path = entry.FullName;
							}

							if (path != "") {
								var newDirectory = Path.Combine(releasePath, path);
								if (!Directory.Exists(newDirectory)) {
									Directory.CreateDirectory(newDirectory);
								}
							}

							ExtractZipEntry(entry, releasePath);
						}
					}
				}

				var appPath = Path.Combine(releasePath, "love.app");

				// Put the .love file in the app resources
				var loveFilePath = Path.Combine(projectPath, "Release/Game.love");
				var newLovePath = Path.Combine(appPath, "Contents/Resources", Path.ChangeExtension(newAppName, "love"));
				File.Copy(loveFilePath, newLovePath);

				// Modify the plist file
				var plistPath = Path.Combine(appPath, "Contents/Info.plist");
				var plist = new Plist(plistPath);

				var pBundleIdentifier = (plist.GetValue("CFBundleIdentifier") as PlistString);
				if (pBundleIdentifier != null) {
					pBundleIdentifier.Value = m_project.m_bundleIdentifier;
				}

				var pBundleName = (plist.GetValue("CFBundleName") as PlistString);
				if (pBundleName != null) {
					pBundleName.Value = m_project.m_name;
				}

				var dict = (plist.Value as PlistDict);
				if (dict.Values.ContainsKey("UTExportedTypeDeclarations")) {
					dict.Values.Remove("UTExportedTypeDeclarations");
				}

				plist.Save();

				// Rename the directory to the new name
				var newAppPath = Path.Combine(releasePath, newAppName);
				Directory.Move(appPath, newAppPath);
			}));
		}

		private void FoundVersions(bool searchDone)
		{
			if (searchDone) {
				labelStatus.Text = "Platforms:";
			} else {
				labelStatus.Text = "Platforms: (still searching)";
			}

			SetPlatformCheckbox(searchDone, "Windows (32 bit)", m_loveVersion.Download_Win32, GetVersionPath("win32"), checkWin32);
			SetPlatformCheckbox(searchDone, "Windows (64 bit)", m_loveVersion.Download_Win64, GetVersionPath("win64"), checkWin64);
			SetPlatformCheckbox(searchDone, "MacOS", m_loveVersion.Download_MacOS, GetVersionPath("macos"), checkMacOS);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonBuild_Click(object sender, EventArgs e)
		{
			buttonBuild.Enabled = false;
			buttonCancel.Enabled = false;

			labelBuildStatus.Visible = true;
			progress.Visible = true;

			BeginLoveBuild();

			if (checkWin32.Checked) { BeginWindowsBuild("win32", m_loveVersion.Download_Win32); }
			if (checkWin64.Checked) { BeginWindowsBuild("win64", m_loveVersion.Download_Win64); }
			if (checkMacOS.Checked) { BeginMacOSBuild("macos", m_loveVersion.Download_MacOS); }

			new Thread(new ThreadStart(() => {
				while (m_tasks.Count > 0) {
					m_tasks[0].RunSynchronously();
					m_tasks.RemoveAt(0);
				}
				Invoke(new Action(() => {
					labelBuildStatus.Text = "Done!";
					MessageBox.Show(this, "Builds finished!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}));
			})).Start();
		}
	}
}
