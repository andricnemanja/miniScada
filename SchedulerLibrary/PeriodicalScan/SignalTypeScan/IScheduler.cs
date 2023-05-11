using ModbusServiceLibrary;
using Quartz;
using SchedulerLibrary.RtuConfiguration;
using System;

namespace SchedulerLibrary.PeriodicalScan.SignalTypeScan
{
	public interface IScheduler
	{
		void RegisterSchedulerJob<T>(TimeSpan time, ISchedulerRtuConfiguration rtuConfiguration, IModbusDuplex modbus) where T : IJob;
	}
}