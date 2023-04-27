using Quartz;
using SchedulerLibrary.Model.Signals;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public class AnalogOutputPeriodicalScanJob: IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (IRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];

			Console.WriteLine();

			foreach (var rtu in rtuConfiguration.ReadAllRTUs())
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is AnalogSignal && signal.AccessType == SignalAccessType.Output)
					{
						Console.WriteLine($"RTU {rtu.ID}, Signal {signal.ID}");
					}
				}
			}

			Console.WriteLine();

			return Task.CompletedTask;
		}
	}
}
