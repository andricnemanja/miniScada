using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public class Scheduler : IScheduler
	{
		public TimeSpan Time { get; }

		private static Quartz.IScheduler scheduler;

		public Scheduler(TimeSpan timeSpan)
		{
			Time = timeSpan;
			Task.Run(() => CreateScheduler());
		}

		private static async Task CreateScheduler()
		{
			var schedulerFactory = new StdSchedulerFactory();

			scheduler = await schedulerFactory.GetScheduler();
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
					.WithInterval(Time)
					.RepeatForever())
				.Build();

			await scheduler.ScheduleJob(readTypes, trigger);

			await scheduler.Start();
		}

	}
}
