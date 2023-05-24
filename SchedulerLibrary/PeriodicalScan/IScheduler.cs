using Quartz;
using SchedulerLibrary.ModbusServiceReference;
using SchedulerLibrary.RtuConfiguration;
using System;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public interface IScheduler
	{
		void RegisterPeriodicalScanJob<T>(TimeSpan time, ISchedulerRtuConfiguration rtuConfiguration, IModbusDuplex modbus) where T : IJob;

		void RegisterCronJob<T>(string cronExpression, ISchedulerRtuConfiguration rtuConfiguration, IModbusDuplex modbus) where T : IJob;

	}
}