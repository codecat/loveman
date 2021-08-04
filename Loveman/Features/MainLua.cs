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
	public class MainLua : IFeature
	{
		public string GetName()
		{
			return "Create main.lua";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.lua16;
			fli.Checked = true;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var mainPath = Path.Combine(project.GetPath(), "main.lua");

			if (project.m_type == LoveType.Love2D) {
				File.WriteAllText(mainPath, @"function love.load()
end

function love.update(dt)
end

function love.draw()
end
");
			} else if (project.m_type == LoveType.Lovr) {
				File.WriteAllText(mainPath, @"function lovr.load()
end

function lovr.update(dt)
end

function lovr.draw()
end
");
			}
		}
	}
}
