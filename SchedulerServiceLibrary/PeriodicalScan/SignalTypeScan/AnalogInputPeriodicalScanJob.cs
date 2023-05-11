using ModbusServiceLibrary.RtuCommands;
using Quartz;
using SchedulerServiceLibrary.ModbusServiceReference;
using SchedulerServiceLibrary.Model.Signals;
using SchedulerServiceLibrary.RtuConfiguration;
using System.Threading.Tasks;

namespace SchedulerServiceLibrary.PeriodicalScan.SignalTypeScan
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
			var rtuConfiguration = (IRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusDuplex)context.JobDetail.JobDataMap["IModbusDuplex"];

			foreach (var rtu in rtuConfiguration.RtuList)
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is AnalogSignal && signal.AccessType == SignalAccessType.Input)
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
