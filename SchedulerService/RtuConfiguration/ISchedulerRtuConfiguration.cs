using SchedulerService.Model.RTU;
using SchedulerService.Model.Signals;
using System.Collections.Generic;

namespace SchedulerService.RtuConfiguration
{
	public interface ISchedulerRtuConfiguration
	{
		List<SchedulerRTU> RtuList { get; }
		ISchedulerSignal GetSignal(int rtuId, int signalId);
		void InitializeData();
		List<SchedulerRTU> ReadAllRTUs();
	}
}