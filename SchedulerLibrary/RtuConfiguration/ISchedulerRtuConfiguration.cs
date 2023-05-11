using SchedulerLibrary.Model.RTU;
using SchedulerLibrary.Model.Signals;
using System.Collections.Generic;

namespace SchedulerLibrary.RtuConfiguration
{
	public interface ISchedulerRtuConfiguration
	{
		List<SchedulerRTU> RtuList { get; }
		ISchedulerSignal GetSignal(int rtuId, int signalId);
		void InitializeData();
		List<SchedulerRTU> ReadAllRTUs();
	}
}