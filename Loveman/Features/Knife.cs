using ICSharpCode.SharpZipLib.Zip;
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
	public class Knife : IFeature
	{
		public string GetName()
		{
			return "Add Knife";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.lua16;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var wc = new WebClient();
			wc.Proxy = null;
			var ms = new MemoryStream(wc.DownloadData("https://github.com/airstruck/knife/archive/refs/heads/master.zip"));
			var zip = new ZipFile(ms);

			var knifePath = Path.Combine(project.GetPath(), "knife");
			Directory.CreateDirectory(knifePath);

			for (int i = 0; i < zip.Count; i++) {
				var f = zip[i];

				if (!f.Name.StartsWith("knife-master/knife/") || !f.Name.EndsWith(".lua")) {
					continue;
				}

				var fs = zip.GetInputStream(f);
				var buffer = new byte[f.Size];
				fs.Read(buffer, 0, (int)f.Size);

				var filePath = Path.Combine(knifePath, Path.GetFileName(f.Name));
				File.WriteAllBytes(filePath, buffer);
			}
		}
	}
}
