using ModbusServiceLibrary.RtuCommands;
using Quartz;
using SchedulerLibrary.ModbusServiceReference;
using SchedulerLibrary.Model.Signals;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	/// <summary>
	/// Job that is periodically executed via scheduler. It scans all analog input type signals.
	/// </summary>
	public class AnalogInputPeriodicalScanJob : IJob
	{
		/// <summary>
		/// Implemetation of a job.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (ISchedulerRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusDuplex)context.JobDetail.JobDataMap["IModbusDuplex"];

			foreach (var rtu in rtuConfiguration.RtuList)
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is SchedulerAnalogSignal && signal.AccessType == SchedulerSignalAccessType.Input)
					{
						IRtuCommand command = new ReadSingleSignalCommand(rtu.ID, signal.ID);
						modbusDuplex.ReceiveCommand(command);
					}
				}
			}

			return Task.CompletedTask;
		}
	}
}
