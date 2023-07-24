using System.Threading.Tasks;
using Quartz;
using SchedulerService.ModbusServiceReference;
using SchedulerService.RtuConfiguration;

namespace SchedulerService.PeriodicalScan.RtuScan
{
	public class RtuScanJob : IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (ISchedulerRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusService)context.JobDetail.JobDataMap["IModbusDuplex"];
			int rtuId = (int)context.JobDetail.JobDataMap["RtuId"];


			foreach (var rtu in rtuConfiguration.RtuList)
			{
				if (rtu.ID == rtuId)
				{
					foreach (var signal in rtu.Signals)
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
