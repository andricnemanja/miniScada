using Quartz;
using SchedulerLibrary.RtuConfiguration;
using System;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public interface IScheduler
	{
		void RegisterSchedulerJob<T>(TimeSpan time, IRtuConfiguration rtuConfiguration) where T : IJob;
	}
}