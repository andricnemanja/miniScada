using SchedulerLibrary.Model.RTU;
using SchedulerLibrary.Model.Signals;
using System.Collections.Generic;

namespace SchedulerLibrary.RtuConfiguration
{
	public interface IRtuConfiguration
	{
		ISignal GetSignal(int rtuId, int signalId);
		void InitializeData();
		List<RTU> ReadAllRTUs();
	}
}