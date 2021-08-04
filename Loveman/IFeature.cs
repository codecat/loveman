using Nimble.Controls.FlatControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loveman
{
	public interface IFeature
	{
		string GetName();
		void ConfigureItem(FlatListItem fli);

		void ApplyFeature(ProjectInfo project);
	}
}
