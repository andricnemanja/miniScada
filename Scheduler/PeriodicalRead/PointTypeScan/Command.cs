using Quartz;
using System;
using System.Threading.Tasks;

namespace Scheduler.PointTypeScan
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
