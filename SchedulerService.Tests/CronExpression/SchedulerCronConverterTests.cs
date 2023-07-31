using SchedulerService.CronExpressionMapper;
using SchedulerService.ModelServiceReference;
using Xunit;

namespace SchedulerService.Tests.CronExpression
{
	public class SchedulerCronConverterTests
	{
		[Theory]
		[InlineData(ModelCronExpressionRecurrenceType.Seconds, 2, "0/2 * * * * ?")]
		[InlineData(ModelCronExpressionRecurrenceType.Minutes, 5, "0 0/5 * 1/1 * ? *")]
		[InlineData(ModelCronExpressionRecurrenceType.Hours, 1, "0 0 0/1 1/1 * ? *")]
		public void CronConverter_(ModelCronExpressionRecurrenceType recurrenceType, int recurrencePeriod, string expectedCron)
		{
			//Act
			var result = CronExpressionConverter.CronConvert(recurrenceType, recurrencePeriod);

			//Assert
			Assert.Equal(expectedCron, result);
		}
	}
}
