using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.ResultsProcessing;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;
using Moq;
using Xunit;

namespace DynamicCacheManager.Tests.ResultProcessing
{
	public class ReadSingleDiscreteSignalResultProcessorTests
	{
		private readonly ReadSingleDiscreteSignalResultProcessor readSingleDiscreteSignalResultProcessor;
		private readonly Mock<IServiceRtuCache> serviceRtuCacheMock;
		private readonly Mock<IDynamicCacheClient> dynamicCacheClientMock;
		public ReadSingleDiscreteSignalResultProcessorTests() 
		{
			serviceRtuCacheMock = new Mock<IServiceRtuCache>();
			dynamicCacheClientMock = new Mock<IDynamicCacheClient>();
			readSingleDiscreteSignalResultProcessor = new ReadSingleDiscreteSignalResultProcessor(serviceRtuCacheMock.Object, dynamicCacheClientMock.Object);
		}

		[Fact]
		public void ProcessCommandResult_NewValueDifferent()
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			string newSignalValue = "Off";
			string currentSignalValue = "On";
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(rtuId, signalId)).Returns(currentSignalValue);
			ReadSingleDiscreteSignalResult command = new ReadSingleDiscreteSignalResult(rtuId, signalId, newSignalValue);

			//Act
			readSingleDiscreteSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(command.RtuId, command.SignalId, newSignalValue));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(command.RtuId, command.SignalId, "DiscreteSignal", newSignalValue));
		}

		[Fact]
		public void ProcessCommandResult_NewValueSameAsOld()
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			string newSignalValue = "Off";
			string currentSignalValue = "Off";
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(rtuId, signalId)).Returns(currentSignalValue);
			ReadSingleDiscreteSignalResult command = new ReadSingleDiscreteSignalResult(1, 1, newSignalValue);

			//Act
			readSingleDiscreteSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(command.RtuId, command.SignalId, newSignalValue), Times.Never);
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(command.RtuId, command.SignalId, "DiscreteSignal", newSignalValue), Times.Never);
		}

	}
}
