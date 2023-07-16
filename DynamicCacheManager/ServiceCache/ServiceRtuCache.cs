using System.Collections.Generic;
using System.Linq;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public class ServiceRtuCache : IServiceRtuCache
	{
		private readonly IStaticDataLoader staticDataLoader;
		public ServiceRtuCache(IStaticDataLoader staticDataLoader) 
		{
			this.staticDataLoader = staticDataLoader;
		}

		public List<Rtu> RtuList { get; private set; }

		public void InitializeData()
		{
			RtuList = staticDataLoader.InitializeData();
		}

		public ISignal GetSignal(int rtuId, int signalId)
		{
			Rtu rtu = RtuList.SingleOrDefault(r => r.Id == rtuId);

			if(rtu == null)
			{
				return null;
			}

			ISignal signal = rtu.AnalogSignals.SingleOrDefault(s => s.Id == signalId);
			if (signal == null)
			{
				signal = rtu.DiscreteSignals.SingleOrDefault(s => s.Id == signalId);
			}

			return signal;
		}
	}
}
