using SchedulerService.Model.SignalPeriod;
using System;
using System.Collections.Generic;

namespace SchedulerService.Period_Mapper
{
	public interface IPeriodMapper
	{
		SignalPeriod FindSignalPeriod(int mappingId);
		TimeSpan FindTimeSpanForSignal(int mappingId);
		List<SignalPeriod> ReadPeriodMapping();
	}
}