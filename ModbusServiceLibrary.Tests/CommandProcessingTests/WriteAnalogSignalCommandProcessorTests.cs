using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.RtuCommands;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandProcessingTests
{
	public class WriteAnalogSignalCommandProcessorTests
	{
		private Mock<IProtocolDriver> protocolDriverMock;

		public WriteAnalogSignalCommandProcessorTests()
		{
			protocolDriverMock = new Mock<IProtocolDriver>();
		}

		[Fact]
		private void ProcessCommand_TryWriteSuccessful_ReturnsWriteAnalogSignalCommandResult()
		{
			//Arrange
			int signalId = 1;
			int rtuId = 1;
			double valueToWrite = 12.5;
			protocolDriverMock.Setup(x => x.WriteAnalogSignal(signalId, valueToWrite)).Returns(true);

			var writeAnalogSignalCommand = new WriteAnalogSignalCommand(rtuId, signalId, valueToWrite);
			var commandProcessor = new WriteAnalogSignalCommandProcessor(protocolDriverMock.Object);

			//Act
			var result = commandProcessor.ProcessCommand(writeAnalogSignalCommand);

			//Assert
			Assert.IsType<WriteAnalogSignalCommandResult>(result);	

		}

		[Fact]
		private void ProcessCommand_TryWriteUnsuccessful_ReturnsWriteAnalogSignalFailedCommandResult()
		{
			//Arrange
			var writeAnalogSignalCommand = new WriteAnalogSignalCommand(1, 1, 12.5);
			protocolDriverMock.Setup(x => x.WriteAnalogSignal(writeAnalogSignalCommand.SignalId, writeAnalogSignalCommand.ValueToWrite)).Returns(false);

			var commandProcessor = new WriteAnalogSignalCommandProcessor(protocolDriverMock.Object);

			//Act
			CommandResultBase result = commandProcessor.ProcessCommand(writeAnalogSignalCommand);

			//Assert
			Assert.IsType<WriteAnalogSignalFailedCommandResult>(result);

		}
	}
}
