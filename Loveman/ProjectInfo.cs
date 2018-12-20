using Nimble.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Loveman
{
	public class ProjectInfo
	{
		private string m_path = "";

		public string m_name = "";
		public string m_author = "";
		public string m_bundleIdentifier = "";
		public string m_loveVersion = "";
		public string m_iconFile = "";

		private bool m_moonscript = false;

		public ProjectInfo(string path)
		{
			m_path = path.Trim('/', '\\');

			var moonFiles = Directory.GetFiles(m_path, "*.moon", SearchOption.AllDirectories);
			m_moonscript = (moonFiles.Length > 0);

			var infoPath = GetInfoPath();
			if (File.Exists(infoPath)) {
				Hashtable obj = (Hashtable)Json.JsonDecode(File.ReadAllText(infoPath));
				if (obj.ContainsKey("name")) { m_name = (string)obj["name"]; }
				if (obj.ContainsKey("author")) { m_author = (string)obj["author"]; }
				if (obj.ContainsKey("bundle-identifier")) { m_bundleIdentifier = (string)obj["bundle-identifier"]; }
				if (obj.ContainsKey("love-version")) { m_loveVersion = (string)obj["love-version"]; }
				if (obj.ContainsKey("icon-file")) { m_iconFile = (string)obj["icon-file"]; }
			}

			if (m_name == "") {
				m_name = Path.GetFileName(m_path);
			}

			if (m_author == "") {
				m_author = "Unknown";
			}

			if (m_bundleIdentifier == "") {
				m_bundleIdentifier = "com.example.game";
			}

			if (m_loveVersion == "") {
				m_loveVersion = LoveVersion.GetInstalledVersion();
			}
		}

		public void SaveJson()
		{
			var obj = new Hashtable();
			obj["name"] = m_name;
			obj["author"] = m_author;
			obj["bundle-identifier"] = m_bundleIdentifier;
			obj["love-version"] = m_loveVersion;
			obj["icon-file"] = m_iconFile;

			var infoPath = GetInfoPath();
			File.WriteAllText(infoPath, Json.JsonEncode(obj));
		}

		public string GetInfoPath()
		{
			return Path.Combine(m_path, "loveman.json");
		}

		public string GetPath()
		{
			return m_path;
		}

		public bool HasMoonscript()
		{
			return m_moonscript;
		}
	}
}
