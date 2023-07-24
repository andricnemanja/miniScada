using System.Threading.Tasks;
using Quartz;
using SchedulerService.ModbusServiceReference;
using SchedulerService.Model.Signals;
using SchedulerService.RtuConfiguration;

namespace SchedulerService.PeriodicalScan.SignalTypeScan
{
	/// <summary>
	/// Job that is periodically executed via scheduler. It scans all discrete input type signals.
	/// </summary>
	public class DiscreteInputPeriodicalScanJob : IJob
	{
		/// <summary>
		/// Implemetation of a job.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (ISchedulerRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusService)context.JobDetail.JobDataMap["IModbusDuplex"];

			foreach (var rtu in rtuConfiguration.RtuList)
			{
				foreach (var signal in rtu.Signals)
				{
					if (signal is SchedulerDiscreteSignal && signal.AccessType == SchedulerSignalAccessType.Output)
					{
						RtuCommandBase command = new ReadSingleSignalCommand { RtuId = rtu.ID, SignalId = signal.ID };
						modbusDuplex.ReceiveCommand(command);
					}
				}
			}

			return Task.CompletedTask;
		}
	}
}
