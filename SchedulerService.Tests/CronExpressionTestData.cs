using SchedulerService.ModelServiceReference;
using System;
using System.Collections.Generic;

namespace SchedulerService.Tests
{
	public static class CronExpressionTestData
	{
		public static List<ModelCronExpressionMapping> GetCronExpressionMappings()
		{
			List<ModelCronExpressionMapping> cronExpressions = new List<ModelCronExpressionMapping>()
			{
				new ModelCronExpressionMapping()
				{
					Id = 1,
					Name = "CronExpression 1",
					Start = new DateTime(2023, 10, 5),
					RecurrenceType = ModelCronExpressionRecurrenceType.Seconds,
					RecurrencePeriod = 2,
					End	= new DateTime(2024, 5, 5)
				},
				new ModelCronExpressionMapping()
				{
					Id = 2,
					Name = "CronExpression 2",
					Start = new DateTime(2023, 10, 6),
					RecurrenceType = ModelCronExpressionRecurrenceType.Seconds,
					RecurrencePeriod = 5,
					End = new DateTime(2024, 5, 5)
				},
				new ModelCronExpressionMapping()
				{
					Id = 3,
					Name = "CronExpression 3",
					Start = new DateTime(2023, 10, 5),
					RecurrenceType = ModelCronExpressionRecurrenceType.Minutes,
					RecurrencePeriod = 2,
					End = new DateTime(2024, 5, 5)
				},
			};

			return cronExpressions;
		}
	}
}
