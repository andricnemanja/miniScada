using Quartz;
using SchedulerLibrary.Model.Signals;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public class AnalogInputPeriodicalScanJob : IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (IRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];

			Console.WriteLine();
			foreach (var rtu in rtuConfiguration.RtuList)
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is AnalogSignal && signal.AccessType == SignalAccessType.Input)
					{
						
					}
				}
			}
			Console.WriteLine();

			return Task.CompletedTask;
		}
	}
}
