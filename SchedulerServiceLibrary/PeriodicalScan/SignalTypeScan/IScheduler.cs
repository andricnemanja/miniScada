using Quartz;
using SchedulerServiceLibrary.ModbusServiceReference;
using SchedulerServiceLibrary.RtuConfiguration;
using System;

namespace SchedulerServiceLibrary.PeriodicalScan.SignalTypeScan
{
	public interface IScheduler
	{
		void RegisterSchedulerJob<T>(TimeSpan time, IRtuConfiguration rtuConfiguration, IModbusDuplex modbus) where T : IJob;
	}
}
