using SchedulerService.ModelServiceReference;

namespace SchedulerService.CronExpressionMapper
{
	/// <summary>
	/// Class that converts user input into the cron expression.
	/// </summary>
	public static class CronExpressionConverter
	{
		/// <summary>
		/// Method that converts recurrence period and recurrence type into cron expression adapted to Quartz.NET scheduler.
		/// </summary>
		/// <param name="recurrenceType">Type of recurrence.</param>
		/// <param name="recurrencePeriod">Period of recurrence.</param>
		/// <returns>Cron expression adapted for scheduler.</returns>
		public static string CronConvert(ModelCronExpressionRecurrenceType recurrenceType, int recurrencePeriod)
		{
			switch (recurrenceType)
			{
				case ModelCronExpressionRecurrenceType.Seconds:
					return $"0/{recurrencePeriod} * * * * ?";
				case ModelCronExpressionRecurrenceType.Minutes:
					return $"0 0/{recurrencePeriod} * 1/1 * ? *";
				case ModelCronExpressionRecurrenceType.Hours:
					return $"0 0 0/{recurrencePeriod} 1/1 * ? *";
				case ModelCronExpressionRecurrenceType.Daily:
					return $"0 0 12 1/{recurrencePeriod} * ? *";
				case ModelCronExpressionRecurrenceType.Weekly:
					return $"0 0 12 ? * MON#{recurrencePeriod} *";
				case ModelCronExpressionRecurrenceType.Monthly:
					return $"0 0 12 1 */{recurrencePeriod} ? *";
				default:
					return null;
					break;
			}
		}
	}
}
