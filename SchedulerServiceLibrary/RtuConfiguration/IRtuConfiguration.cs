using SchedulerServiceLibrary.Model.RTU;
using SchedulerServiceLibrary.Model.Signals;
using System.Collections.Generic;

namespace SchedulerServiceLibrary.RtuConfiguration
{
	public interface IRtuConfiguration
	{
		List<RTU> RtuList { get; }
		ISignal GetSignal(int rtuId, int signalId);
		void InitializeData();
		List<RTU> ReadAllRTUs();
	}
}
