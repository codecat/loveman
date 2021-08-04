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
	public class ConfLua : IFeature
	{
		public string GetName()
		{
			return "Create conf.lua";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.lua16;
			fli.Checked = true;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var mainPath = Path.Combine(project.GetPath(), "conf.lua");

			if (project.m_type == LoveType.Love2D) {
				File.WriteAllText(mainPath, @"function love.conf(t)
	t.window.title = '" + project.m_name.Replace("'", "\\'") + @"'
	t.window.width = 800
	t.window.height = 600
	t.window.msaa = 4
end
");
			} else if (project.m_type == LoveType.Lovr) {
				File.WriteAllText(mainPath, @"function lovr.conf(t)
	t.window.title = '" + project.m_name.Replace("'", "\\'") + @"'
	t.window.width = 1080
	t.window.height = 600
end
");
			}
		}
	}
}
