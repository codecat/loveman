using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loveman
{
	public static class Program
	{
		public static FormMain MainForm;

		public static string Version = "1.1.0.0";

		[STAThread]
		static void Main()
		{
			string appFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
			Environment.CurrentDirectory = appFolder;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(MainForm = new FormMain());
		}
	}
}
