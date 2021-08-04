using Loveman.Properties;
using Nimble.Controls.FlatControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loveman.Features
{
	public class VSCodeConfig : IFeature
	{
		public string GetName()
		{
			return "VS Code configuration";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.code16;

			var editorExe = Path.GetFileName(Settings.Default.Path_Editor);
			fli.Checked = (editorExe == "Code.exe" || editorExe == "VSCodium.exe");
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var vscodePath = Path.Combine(project.GetPath(), ".vscode");
			Directory.CreateDirectory(vscodePath);

			var settingsPath = Path.Combine(vscodePath, "settings.json");

			//TODO: This currently only works for LOVE, not LOVR
			if (project.m_type == LoveType.Love2D) {
				File.WriteAllText(settingsPath, @"{
	""Lua.runtime.version"": ""LuaJIT"",
	""Lua.workspace.library"": [
		""${3rd}/love2d/library""
	],
	""Lua.workspace.checkThirdParty"": false
}
");
			}
		}
	}
}
