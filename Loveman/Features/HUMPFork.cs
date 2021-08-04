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
	public class HUMPFork : IFeature
	{
		public string GetName()
		{
			return "Add HUMP fork (HDictus/hump)";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.love16;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			var wc = new WebClient();
			wc.Proxy = null;
			var ms = new MemoryStream(wc.DownloadData("https://github.com/HDictus/hump/archive/refs/heads/temp-master.zip"));
			var zip = new ZipFile(ms);

			var humpPath = Path.Combine(project.GetPath(), "hump");
			if (Directory.Exists(humpPath)) {
				throw new Exception("Only one version of HUMP can be used!");
			}

			Directory.CreateDirectory(humpPath);

			for (int i = 0; i < zip.Count; i++) {
				var f = zip[i];

				string fname = f.Name.Substring("hump-temp-master/".Length);
				if (fname.Contains('/') || !f.Name.EndsWith(".lua")) {
					continue;
				}

				var fs = zip.GetInputStream(f);
				var buffer = new byte[f.Size];
				fs.Read(buffer, 0, (int)f.Size);

				var filePath = Path.Combine(humpPath, Path.GetFileName(fname));
				File.WriteAllBytes(filePath, buffer);
			}
		}
	}
}
