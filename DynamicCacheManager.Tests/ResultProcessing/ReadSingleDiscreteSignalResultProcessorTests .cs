using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
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
			DiscreteSignal discreteSignal = new DiscreteSignal(1, 1);
			string newSignalValue = "Off";
			string currentSignalValue = "On";
			serviceRtuCacheMock.Setup(s => s.GetSignal(It.IsAny<int>(), It.IsAny<int>())).Returns(discreteSignal);
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(discreteSignal)).Returns(currentSignalValue);
			ReadSingleDiscreteSignalResult command = new ReadSingleDiscreteSignalResult(1, 1, newSignalValue);

			//Act
			readSingleDiscreteSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(discreteSignal, newSignalValue));
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(discreteSignal, newSignalValue));
		}

		[Fact]
		public void ProcessCommandResult_NewValueSameAsOld()
		{
			//Arrange
			DiscreteSignal discreteSignal = new DiscreteSignal(1, 1);
			string newSignalValue = "Off";
			string currentSignalValue = "Off";
			serviceRtuCacheMock.Setup(s => s.GetSignal(It.IsAny<int>(), It.IsAny<int>())).Returns(discreteSignal);
			dynamicCacheClientMock.Setup(d => d.GetSignalValue(discreteSignal)).Returns(currentSignalValue);
			ReadSingleDiscreteSignalResult command = new ReadSingleDiscreteSignalResult(1, 1, newSignalValue);

			//Act
			readSingleDiscreteSignalResultProcessor.ProcessCommandResult(command);

			//Assert
			dynamicCacheClientMock.Verify(d => d.ChangeSignalValue(discreteSignal, newSignalValue), Times.Never);
			dynamicCacheClientMock.Verify(d => d.PublishSignalChange(discreteSignal, newSignalValue), Times.Never);
		}

	}
}
