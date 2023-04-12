using System;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public interface IScheduler
	{
		TimeSpan Time { get; }

		void StartScheduler();
	}
}
