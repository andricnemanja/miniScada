using SchedulerService.ModelServiceReference;
using System;
using System.Collections.Generic;

namespace SchedulerService.Tests
{
	public static class PeriodMappingTestData
	{
		public static List<SignalScanPeriodMapping> GetPeriodMappingsTestList()
		{
			List<SignalScanPeriodMapping> periodMappingsList = new List<SignalScanPeriodMapping>()
			{
				new SignalScanPeriodMapping()
				{
					Id = 1,
					Name = "PeriodMapping 1",
					TimeStamp = new TimeSpan(0, 0, 5)
				},
				new SignalScanPeriodMapping()
				{
					Id = 2,
					Name = "PeriodMapping 2",
					TimeStamp = new TimeSpan(0, 0, 2)
				},
				new SignalScanPeriodMapping()
				{
					Id = 3,
					Name = "PeriodMapping 3",
					TimeStamp = new TimeSpan(0, 0, 15)
				},
			};

			return periodMappingsList;
		}
	}
}
