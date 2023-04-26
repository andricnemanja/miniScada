using System.Collections.Generic;
using System.Linq;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public class ServiceRtuCache : IServiceRtuCache
	{
		public List<Rtu> RtuList { get; set; }

		public ISignal GetSignal(int rtuId, int signalId)
		{
			Rtu rtu = RtuList.SingleOrDefault(r => r.Id == rtuId);

			ISignal signal = rtu.AnalogSignals.SingleOrDefault(s => s.Id == signalId);
			if (signal == null)
			{
				signal = rtu.DiscreteSignals.SingleOrDefault(s => s.Id == signalId);
			}

			return signal;
		}
	}
}
