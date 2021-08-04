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
	public class LeanClass : IFeature
	{
		public string GetName()
		{
			return "Add class.lua (smaller hump.class)";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.lua16;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var classPath = Path.Combine(project.GetPath(), "class.lua");
			File.WriteAllBytes(classPath, Resources._class);
		}
	}
}
