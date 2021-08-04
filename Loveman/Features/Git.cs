using Loveman.Properties;
using Nimble.Controls.FlatControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loveman.Features
{
	public class Git : IFeature
	{
		public string GetName()
		{
			return "Initialize Git repository";
		}

		public void ConfigureItem(FlatListItem fli)
		{
			fli.Image = Resources.git16;
		}

		public void ApplyFeature(ProjectInfo project)
		{
			try {
				Process.Start(new ProcessStartInfo("git", "init") {
					WorkingDirectory = project.GetPath(),
					WindowStyle = ProcessWindowStyle.Hidden
				}).WaitForExit();
			} catch {
				throw new Exception("\"git\" is not available in %PATH%");
			}
		}
	}
}
