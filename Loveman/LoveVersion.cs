using Loveman.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Loveman
{
	public class LoveVersion
	{
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

		public static string GetInstalledVersion()
		{
			var exePath = Path.Combine(Settings.Default.Path_Love, "love.exe");
			var version = FileVersionInfo.GetVersionInfo(exePath);
			return version.FileVersion;
		}
	}
}
