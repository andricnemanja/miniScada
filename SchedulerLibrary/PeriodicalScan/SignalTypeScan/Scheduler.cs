using Quartz;
using Quartz.Impl;
using SchedulerLibrary.RtuConfiguration;
using System;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
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
		/// Class that registers jobs to the scheduler.
		/// </summary>
		/// <typeparam name="T">Generic type that has to be <see cref="IScheduler"/>.</typeparam>
		/// <param name="time">Time of the periodical scan of the signal.</param>
		/// <param name="rtuConfiguration">Instance of class that carries crutial information about Rtus and it's signals.</param>
		/// <param name="modbus">Instace that enables us to communicate with Modbus service.</param>
		public async void RegisterSchedulerJob<T>(TimeSpan time, IRtuConfiguration rtuConfiguration, ModbusServiceLibrary.IModbusDuplex modbus) where T : IJob
		{
			var schedulerJob = JobBuilder.Create<T>()
				.WithIdentity(typeof(T).FullName)
				.Build();

			schedulerJob.JobDataMap["RtuConfiguration"] = rtuConfiguration;
			schedulerJob.JobDataMap["IModbusDuplex"] = modbus;

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
