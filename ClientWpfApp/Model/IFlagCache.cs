using System.Collections.Generic;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.Model
{
	public interface IFlagCache
	{
		List<Flag> Flags { get; set; }

		Flag FindFlag(int flagId);
		void ReadFlagStaticData();
	}
}