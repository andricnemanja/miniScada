using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
using Moq;
using Xunit;
using AnalogSignal = ModbusServiceLibrary.Model.Signals.ModbusAnalogSignal;
using DiscreteSignal = ModbusServiceLibrary.Model.Signals.ModbusDiscreteSignal;

namespace ModbusServiceLibrary.Tests.CommandProcessingTests
{
	public class ReadSingleSignalCommandProcessorTests
	{
		private Mock<IModbusRtuConfiguration> rtuConfigurationMock;
		private Mock<IProtocolDriver> protocolDriverMock;

		public ReadSingleSignalCommandProcessorTests()
		{
			rtuConfigurationMock = new Mock<IModbusRtuConfiguration>();
			protocolDriverMock = new Mock<IProtocolDriver>();
		}

		[Fact]
		private void ProcessCommand_ReadAnalogSignalValue_ReturnsReadSingleAnalogSignalResult()
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			double signalValue = 10.11;

			var analogSignal = new AnalogSignal(signalId, "AnalogSignal1");

			rtuConfigurationMock.Setup(x => x.GetSignal(rtuId, signalId)).Returns(analogSignal);
			protocolDriverMock.Setup(x => x.ReadAnalogSignal(signalId, out signalValue)).Returns(true);

			var readSingleSignalCommand = new ReadSingleSignalCommand(rtuId, signalId);
			var processor = new ReadSingleSignalCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			CommandResultBase result = processor.ProcessCommand(readSingleSignalCommand);

			//Assert
			Assert.IsType<ReadSingleAnalogSignalResult>(result);		
		}

		[Fact]
		private void ProcessCommand_ReadDiscreteSignalValue_ReturnsReadSingleDiscreteSignalResult()
		{
			//Arrange
			int rtuId = 1;
			int signalId = 1;
			string signalState = "On";

			var discreteSignal = new DiscreteSignal(signalId, "DiscreteSignal1");

			rtuConfigurationMock.Setup(x => x.GetSignal(rtuId, signalId)).Returns(discreteSignal);
			protocolDriverMock.Setup(x => x.ReadDiscreteSignal(signalId, out signalState)).Returns(true);

			var readSingleSignalCommand = new ReadSingleSignalCommand(rtuId, signalId);
			var processor = new ReadSingleSignalCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			CommandResultBase result = processor.ProcessCommand(readSingleSignalCommand);

			//Assert
			Assert.IsType<ReadSingleDiscreteSignalResult>(result);
		}

	}
}
