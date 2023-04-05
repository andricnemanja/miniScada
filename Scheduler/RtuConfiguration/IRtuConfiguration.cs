using Scheduler.Model.RTU;
using Scheduler.Model.Signals;
using System.Collections.Generic;

namespace Scheduler.RtuConfiguration
{
	public interface IRtuConfiguration
	{
		ISignal GetSignal(int rtuId, int signalId);
		void InitializeData();
		List<RTU> ReadAllRTUs();
	}
}