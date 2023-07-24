using Quartz;
using SchedulerService.ModbusServiceReference;
using SchedulerService.RtuConfiguration;
using System;

namespace SchedulerService.PeriodicalScan
{
	public interface IScheduler
	{
		void RegisterPeriodicalScanJob<T>(TimeSpan time, ISchedulerRtuConfiguration rtuConfiguration, IModbusService modbus, int rtuId = 0) where T : IJob;

		void RegisterCronJob<T>(string cronExpression, ISchedulerRtuConfiguration rtuConfiguration, IModbusService modbus, int rtuId = 0) where T : IJob;

	}
}