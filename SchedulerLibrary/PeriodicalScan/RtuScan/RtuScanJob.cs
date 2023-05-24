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

namespace SchedulerLibrary.PeriodicalScan.RtuScan
{
	public class RtuScanJob : IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			var rtuConfiguration = (ISchedulerRtuConfiguration)context.JobDetail.JobDataMap["RtuConfiguration"];
			var modbusDuplex = (IModbusDuplex)context.JobDetail.JobDataMap["IModbusDuplex"];
			int rtuId = 2;


			foreach (var rtu in rtuConfiguration.RtuList)
			{
				if (rtu.ID == rtuId)
				{
					foreach (var signal in rtu.Signals)
					{
						RtuCommandBase command = new ReadSingleSignalCommand(rtu.ID, signal.ID);
						modbusDuplex.ReceiveCommand(command);
					}
				}
			}

			return Task.CompletedTask;
		}
	}
}
