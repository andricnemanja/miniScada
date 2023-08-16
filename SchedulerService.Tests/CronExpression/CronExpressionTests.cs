using Moq;
using SchedulerService.CronExpressionMapper;
using SchedulerService.ModelServiceReference;
using Xunit;

namespace SchedulerService.Tests.CronExpression
{
	public class CronExpressionTests
	{
		private readonly ISchedulerCronExpressionMapper cronExpressionMapper;

		public CronExpressionTests()
		{
			Mock<IModelService> modelServiceMock = new Mock<IModelService>();
			modelServiceMock.Setup(x => x.GetCronExpressionMappings()).Returns(CronExpressionTestData.GetCronExpressionMappings().ToArray);

			cronExpressionMapper = new SchedulerCronExpressionMapper(modelServiceMock.Object);
		}

		[Fact]
		public void ReadCronExpressions_Should_ReturnListOfCronExpressions()
		{
			// Act
			var result = cronExpressionMapper.ReadCronExpressions();

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(3, result.Count);
		}
		//Da nema ni jednog


		[Fact]
		public void FindCronExpression_ExistingMappingId_Should_ReturnCronExpression()
		{
			// Arrange
			int existingMappingId = 2;

			// Act
			var cronExpression = cronExpressionMapper.FindCronExpression(existingMappingId);

			// Assert
			Assert.NotNull(cronExpression);
			Assert.Equal(existingMappingId, cronExpression.Id);
		}
	}
}
