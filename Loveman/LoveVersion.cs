using Loveman.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Loveman
{
	public class LoveVersion
	{
		public LoveType Type = LoveType.Love2D;
		public string Version = "";

		public string Download_Win32 = "";
		public string Download_Win64 = "";
		public string Download_MacOS = "";

		public bool HasAllDownloads()
		{
			return
				Download_Win32 != "" &&
				Download_Win64 != "" &&
				Download_MacOS != "";
		}

		public static string GetInstalledVersion(LoveType type)
		{
			if (type == LoveType.Love2D) {
				var exePath = Path.Combine(Settings.Default.Path_Love, "love.exe");
				var version = FileVersionInfo.GetVersionInfo(exePath);
				return version.FileVersion;

			} else if (type == LoveType.Lovr) {
				var exePath = Path.Combine(Settings.Default.Path_Lovr, "lovr.exe");

				var startInfo = new ProcessStartInfo();
				startInfo.FileName = exePath;
				startInfo.Arguments = "--version";
				startInfo.UseShellExecute = false;
				startInfo.RedirectStandardOutput = true;

				var proc = Process.Start(startInfo);
				string version = proc.StandardOutput.ReadToEnd();

				var match = Regex.Match(version, @"^LOVR ([^\s]+) \(.*\)");
				if (!match.Success) {
					return "???";
				}

				return "v" + match.Groups[1].Value;
			}

			return "???";
		}
	}
}
