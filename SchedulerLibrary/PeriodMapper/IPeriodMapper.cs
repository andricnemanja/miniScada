using SchedulerLibrary.Model.SignalPeriod;
using System;
using System.Collections.Generic;

namespace SchedulerLibrary.Period_Mapper
{
	public interface IPeriodMapper
	{
		SignalPeriod FindSignalPeriod(int mappingId);
		TimeSpan FindTimeSpanForSignal(int mappingId);
		List<SignalPeriod> ReadPeriodMapping();
	}
}