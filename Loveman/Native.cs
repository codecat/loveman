using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Loveman
{
	public static class Native
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr BeginUpdateResource(string pFileName, [MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool UpdateResource(IntPtr hUpdate, IntPtr lpType, IntPtr lpName, ushort wLanguage, IntPtr lpData, uint cbData);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool DestroyIcon(IntPtr handle);
	}
}
