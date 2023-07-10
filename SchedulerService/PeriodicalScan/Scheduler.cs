using System;
using Quartz;
using Quartz.Impl;
using SchedulerService.ModbusServiceReference;
using SchedulerService.RtuConfiguration;

namespace SchedulerService.PeriodicalScan
{
	/// <summary>
	/// Class that schedules different tasks.
	/// </summary>
	public class Scheduler : IScheduler
	{
		private static Quartz.IScheduler scheduler;

		public Scheduler()
		{
			CreateScheduler();
		}

		/// <summary>
		/// Method that instantiates <see cref="IScheduler"/ class.>
		/// </summary>
		private static async void CreateScheduler()
		{
			var schedulerFactory = new StdSchedulerFactory();

			scheduler = await schedulerFactory.GetScheduler();
		}

		/// <summary>
		/// Method that registers periodical scan jobs to the scheduler.
		/// </summary>
		/// <typeparam name="T">Generic type that has to be <see cref="IJob"/>.</typeparam>
		/// <param name="time">Time of the periodical scan of the signal.</param>
		/// <param name="rtuConfiguration">Instance of class that carries crutial information about Rtus and it's signals.</param>
		/// <param name="modbus">Instace that enables us to communicate with Modbus service.</param>
		public async void RegisterPeriodicalScanJob<T>(TimeSpan time, ISchedulerRtuConfiguration rtuConfiguration, IModbusDuplex modbus, int rtuId = 0) where T : IJob
		{
			var schedulerJob = JobBuilder.Create<T>()
				.Build();

			schedulerJob.JobDataMap["RtuConfiguration"] = rtuConfiguration;
			schedulerJob.JobDataMap["IModbusDuplex"] = modbus;
			schedulerJob.JobDataMap["RtuId"] = rtuId;

			var trigger = TriggerBuilder.Create()
				.StartNow()
				.WithSimpleSchedule(x => x
					.WithInterval(time)
					.RepeatForever())
				.Build();

			await scheduler.ScheduleJob(schedulerJob, trigger);

			await scheduler.Start();
		}

		/// <summary>
		/// Method that register cron jobs to the scheduler.
		/// </summary>
		/// <typeparam name="T">Generic type that has to be <see cref="IJob"/>.</typeparam>
		/// <param name="cronExpression">Expression that represents period that cron job should execute.</param>
		/// <param name="rtuConfiguration">Instance of class that carries crutial information about Rtus and it's signals.</param>
		/// <param name="modbus">Instace that enables us to communicate with Modbus service.</param>
		public async void RegisterCronJob<T>(string cronExpression, ISchedulerRtuConfiguration rtuConfiguration, IModbusDuplex modbus, int rtuId = 0) where T : IJob
		{
			var schedulerJob = JobBuilder.Create<T>()
				.Build();

			schedulerJob.JobDataMap["RtuConfiguration"] = rtuConfiguration;
			schedulerJob.JobDataMap["IModbusDuplex"] = modbus;
			schedulerJob.JobDataMap["RtuId"] = rtuId;

			var trigger = TriggerBuilder.Create()
				.WithCronSchedule("0/2 * * ? * * *")
				.Build();

			await scheduler.ScheduleJob(schedulerJob, trigger);

			await scheduler.Start();
		}
	}
}
