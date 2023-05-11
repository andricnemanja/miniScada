using SchedulerServiceLibrary.Model.SignalPeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerServiceLibrary.PeriodMapper
{
	public interface IPeriodMapper
	{
		SignalPeriod FindSignalPeriod(int mappingId);
		TimeSpan FindTimeSpanForSignal(int mappingId);
		List<SignalPeriod> ReadPeriodMapping();
	}
}
