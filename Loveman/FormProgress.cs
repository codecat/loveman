using Nimble.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loveman
{
	public partial class FormProgress : Form
	{
		public FormProgress()
		{
			InitializeComponent();

			Interface.InterfaceTheme(this);
		}

		public void WaitUntilCreated()
		{
			while (!IsHandleCreated) {
				Thread.Sleep(10);
			}
		}

		public void SetStatus(double scale, string text)
		{
			Invoke(new Action(() => {
				labelText.Text = text;
				progress.Value = (int)(scale * 100);
			}));
		}

		public void Finished()
		{
			Invoke(new Action(() => {
				Close();
			}));
		}
	}
}
