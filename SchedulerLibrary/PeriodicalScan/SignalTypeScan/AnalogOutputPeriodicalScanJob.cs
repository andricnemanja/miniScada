using ModbusServiceLibrary;
using ModbusServiceLibrary.RtuCommands;
using Quartz;
using SchedulerLibrary.Model.Signals;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	/// <summary>
	/// Job that is periodically executed via scheduler. It scans all analog output type signals.
	/// </summary>
	public class AnalogOutputPeriodicalScanJob: IJob
	{
		/// <summary>
		/// Implemetation of a job.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (IRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusDuplex)context.JobDetail.JobDataMap["IModbusDuplex"];

			foreach (var rtu in rtuConfiguration.ReadAllRTUs())
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is AnalogSignal && signal.AccessType == SignalAccessType.Output)
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
