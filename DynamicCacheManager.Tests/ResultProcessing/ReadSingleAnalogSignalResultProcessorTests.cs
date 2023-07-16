using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ResultsProcessing;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;
using Moq;
using Xunit;

namespace DynamicCacheManager.Tests.ResultProcessing
{
	public class ReadSingleAnalogSignalResultProcessorTests
	{
		private readonly ReadSingleAnalogSignalResultProcessor readSingleAnalogSignalResultProcessor;
		private readonly Mock<IServiceRtuCache> serviceRtuCacheMock;
		private readonly Mock<IDynamicCacheClient> dynamicCacheClientMock;
		public ReadSingleAnalogSignalResultProcessorTests() 
		{
			serviceRtuCacheMock = new Mock<IServiceRtuCache>();
			dynamicCacheClientMock = new Mock<IDynamicCacheClient>();
			readSingleAnalogSignalResultProcessor = new ReadSingleAnalogSignalResultProcessor(serviceRtuCacheMock.Object, dynamicCacheClientMock.Object);
		}


		[Theory]
		[InlineData("10", 14, 3)]
		[InlineData("14", 10, 3)]
		public void ProcessCommandResult_ChangeGreaterThanDeadband(string currentSignalValue, double newSignalValue, double deadband)
		{
			//Arrange
			AnalogSignal analogSignal = new AnalogSignal(1, 1, deadband);
			serviceRtuCacheMock.Setup(s => s.GetSignal(It.IsAny<int>(), It.IsAny<int>())).Returns(analogSignal);
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(analogSignal)).Returns(currentSignalValue);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(1, 1, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(analogSignal, newSignalValue.ToString()));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(analogSignal, newSignalValue.ToString()));
		}

		[Theory]
		[InlineData("10", 14, 5)]
		[InlineData("14", 10, 5)]
		[InlineData("10", 14, 4)]
		[InlineData("14", 10, 4)]
		public void ProcessCommandResult_ChangeLowerThanDeadband(string currentSignalValue, double newSignalValue, double deadband)
		{
			//Arrange
			AnalogSignal analogSignal = new AnalogSignal(1, 1, deadband);
			serviceRtuCacheMock.Setup(s => s.GetSignal(It.IsAny<int>(), It.IsAny<int>())).Returns(analogSignal);
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(analogSignal)).Returns(currentSignalValue);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(1, 1, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(analogSignal, newSignalValue.ToString()), Times.Never);
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(analogSignal, newSignalValue.ToString()), Times.Never);
		}

		[Fact]
		public void ProcessCommandResult_CacheValueDoesNotExist()
		{
			//Arrange
			AnalogSignal analogSignal = new AnalogSignal(1, 1, 1);
			double newSignalValue = 0;
			serviceRtuCacheMock.Setup(s => s.GetSignal(It.IsAny<int>(), It.IsAny<int>())).Returns(analogSignal);
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(analogSignal)).Returns(string.Empty);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(1, 1, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(analogSignal, newSignalValue.ToString()));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(analogSignal, newSignalValue.ToString()));
		}

	}
}
