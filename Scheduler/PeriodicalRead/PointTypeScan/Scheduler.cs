using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace Scheduler.PointTypeScan
{
	public class Scheduler : IScheduler
	{
		public int seconds { get; }

		private static Quartz.IScheduler _scheduler;

		public Scheduler(int seconds)
		{
			this.seconds = seconds;
			Task.Run(() => CreateScheduler());
		}

		private static async Task CreateScheduler()
		{
			var schedulerFactory = new StdSchedulerFactory();

			_scheduler = await schedulerFactory.GetScheduler();
		}

		public async void StartScheduler()
		{
			var readTypes = JobBuilder.Create<Command>()
				.WithIdentity("readTypes", "typeReading")
				.Build();

			var trigger = TriggerBuilder.Create()
				.WithIdentity("Trigger", "typeReading")
				.StartNow()
				.WithSimpleSchedule(x => x
					.WithIntervalInSeconds(seconds)
					.RepeatForever())
				.Build();

			await _scheduler.ScheduleJob(readTypes, trigger);

			await _scheduler.Start();
		}
	}
}
