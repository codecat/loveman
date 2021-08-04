using Loveman.Properties;
using Nimble.Controls.FlatControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Loveman.Features
{
	public class Lurker : IFeature
	{
		public string GetName()
		{
			return "Add Lurker (live-reload)";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.lua16;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var wc = new WebClient();
			wc.Proxy = null;

			var lumePath = Path.Combine(project.GetPath(), "lume.lua");
			if (!File.Exists(lumePath)) {
				wc.DownloadFile("https://raw.githubusercontent.com/rxi/lume/master/lume.lua", lumePath);
			}

			var lurkerPath = Path.Combine(project.GetPath(), "lurker.lua");
			wc.DownloadFile("https://raw.githubusercontent.com/rxi/lurker/master/lurker.lua", lurkerPath);
		}
	}
}
