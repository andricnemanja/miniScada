using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.ModelServiceReference;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
using ModbusServiceLibrary.Model.Signals;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AnalogSignal = ModbusServiceLibrary.Model.Signals.AnalogSignal;
using DiscreteSignal = ModbusServiceLibrary.Model.Signals.DiscreteSignal;

namespace ModbusServiceLibrary.Tests.CommandProcessingTests
{
	public class ReadSingleSignalCommandProcessorTests
	{
		private Mock<IRtuConfiguration> rtuConfigurationMock;
		private Mock<IProtocolDriver> protocolDriverMock;

		public ReadSingleSignalCommandProcessorTests()
		{
			rtuConfigurationMock = new Mock<IRtuConfiguration>();
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
			protocolDriverMock.Setup(x => x.ReadAnalogSignal(signalId)).Returns(signalValue);

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
			protocolDriverMock.Setup(x => x.ReadDiscreteSignal(signalId)).Returns(signalState);

			var readSingleSignalCommand = new ReadSingleSignalCommand(rtuId, signalId);
			var processor = new ReadSingleSignalCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			CommandResultBase result = processor.ProcessCommand(readSingleSignalCommand);

			//Assert
			Assert.IsType<ReadSingleDiscreteSignalResult>(result);
		}

	}
}
