using Moq;
using SchedulerService.ModelServiceReference;
using SchedulerService.Period_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchedulerService.Tests.PeriodMapper
{
	public class PeriodMapperTests
	{
		private readonly IPeriodMapper periodMapper;

		public PeriodMapperTests()
		{
			Mock<IModelService> modelServiceMock = new Mock<IModelService>();
			modelServiceMock.Setup(x => x.GetSignalScanPeriodMappings()).Returns(PeriodMappingTestData.GetPeriodMappingsTestList().ToArray);

			periodMapper = new Period_Mapper.PeriodMapper(modelServiceMock.Object);
		}

		[Fact]
		public void ReadPeriodMapping_ShouldReturnListOfSignalPeriods()
		{
			//Act
			var result = periodMapper.ReadPeriodMapping();

			//Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Equal(3, result.Count);
		}

		[Fact]
		public void FindSignalPeriod_ExistingMappingId_ShouldReturnSignalPeriod()
		{
			//Arrange
			int existingId = 3;

			//Act
			var result = periodMapper.FindSignalPeriod(existingId);

			//Assert
			Assert.Equal(existingId, result.Id);

		}

		[Fact]
		public void FindTimeSpanForSignal_ExistingMappingId_ShouldReturnTimeSpan()
		{
			//Arrange
			int existingId = 2;

			//Act
			var result = periodMapper.FindTimeSpanForSignal(existingId);

			//Assert
			Assert.Equal(periodMapper.FindSignalPeriod(existingId).TimeStamp, result);
		}




	}
}
