using Quartz;
using Quartz.Impl;
using SchedulerLibrary.Model.SignalPeriod;
using SchedulerLibrary.Period_Mapper;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public class Scheduler : IScheduler
	{
		private static Quartz.IScheduler scheduler;

		public Scheduler()
		{
			CreateScheduler();
		}

		private static async void CreateScheduler()
		{
			var schedulerFactory = new StdSchedulerFactory();

			scheduler = await schedulerFactory.GetScheduler();
		}

		public async void RegisterSchedulerJob<T>(TimeSpan time, IRtuConfiguration rtuConfiguration) where T : Quartz.IJob
		{
			var schedulerJob = JobBuilder.Create<T>()
				.WithIdentity(typeof(T).FullName)
				.Build();

			schedulerJob.JobDataMap["RtuConfiguration"] = rtuConfiguration;

			var trigger = TriggerBuilder.Create()
				.WithIdentity(typeof(T).FullName)
				.StartNow()
				.WithSimpleSchedule(x => x
					.WithInterval(time)
					.RepeatForever())
				.Build();

			await scheduler.ScheduleJob(schedulerJob, trigger);

			await scheduler.Start();
		}
	}
}
