using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public class Command : IJob
	{		
		public Task Execute(IJobExecutionContext context)
		{
			Console.WriteLine("asdadadadad");
			return Task.CompletedTask;
		}		
	}
}
