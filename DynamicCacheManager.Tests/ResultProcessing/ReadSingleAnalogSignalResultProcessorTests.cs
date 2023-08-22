using DynamicCacheManager.DynamicCacheClient;
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
			int rtuId = 1;
			int signalId = 1;
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(rtuId, signalId)).Returns(currentSignalValue);
			dynamicCacheClientMock.Setup(d => d.GetAnalogSignalDeadband(rtuId, signalId)).Returns(deadband);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(rtuId, signalId, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(command.RtuId, command.SignalId, newSignalValue.ToString()));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(command.RtuId, command.SignalId, "AnalogSignal", newSignalValue.ToString()));
		}

		[Theory]
		[InlineData("10", 14, 5)]
		[InlineData("14", 10, 5)]
		[InlineData("10", 14, 4)]
		[InlineData("14", 10, 4)]
		public void ProcessCommandResult_ChangeLowerThanDeadband(string currentSignalValue, double newSignalValue, double deadband)
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(rtuId, signalId)).Returns(currentSignalValue);
			dynamicCacheClientMock.Setup(d => d.GetAnalogSignalDeadband(rtuId, signalId)).Returns(deadband);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(rtuId, signalId, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(command.RtuId, command.SignalId, newSignalValue.ToString()), Times.Never);
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(command.RtuId, command.SignalId, "AnalogSignal", newSignalValue.ToString()), Times.Never);
		}

		[Fact]
		public void ProcessCommandResult_CacheValueDoesNotExist()
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			double newSignalValue = 0;
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(rtuId, signalId)).Returns(string.Empty);
			ReadSingleAnalogSignalResult command = new ReadSingleAnalogSignalResult(rtuId, signalId, newSignalValue);

			//Act
			readSingleAnalogSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(rtuId, signalId, newSignalValue.ToString()));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(rtuId, signalId, "AnalogSignal", newSignalValue.ToString()));
		}

	}
}
