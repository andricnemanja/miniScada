using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
using ModbusServiceLibrary.Tests.CommandTests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
