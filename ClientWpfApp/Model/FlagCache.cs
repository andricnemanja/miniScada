using System.Collections.Generic;
using System.Linq;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Model
{
	public sealed class FlagCache : IFlagCache
	{
		public List<Flag> Flags { get; set; } = new List<Flag>();

		public void ReadFlagStaticData()
		{
			ModelServiceConverter modelServiceConverter = new ModelServiceConverter(new ModelServiceReference.ModelServiceClient());
			Flags = modelServiceConverter.ReadAllFlags();
		}

		public Flag FindFlag(int flagId)
		{
			return Flags.SingleOrDefault(f => f.ID == flagId);
		}
	}
}
