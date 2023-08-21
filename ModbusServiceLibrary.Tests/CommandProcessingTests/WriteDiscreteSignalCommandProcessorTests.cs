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
	public class WriteDiscreteSignalCommandProcessorTests
	{
		private Mock<IProtocolDriver> protocolDriverMock;

		public WriteDiscreteSignalCommandProcessorTests()
		{
			protocolDriverMock = new Mock<IProtocolDriver>();
		}

		[Fact]
		private void ProcessCommand_TryWriteSuccessful_ReturnsWriteDiscreteSignalCommandResult()
		{
			//Arrange
			var writeDiscreteSignalCommand = new WriteDiscreteSignalCommand(1, 1, "On");
			protocolDriverMock.Setup(x => x.WriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State)).Returns(true);

			var commandProcessor = new WriteDiscreteSignalCommandProcessor(protocolDriverMock.Object);

			//Act
			CommandResultBase result = commandProcessor.ProcessCommand(writeDiscreteSignalCommand);

			//Assert
			Assert.IsType<WriteDiscreteSignalCommandResult>(result);
		}

		[Fact]
		private void ProcessCommand_TryWriteUnsuccessful_ReturnsWriteDiscreteSignalFailedCommandResult()
		{
			//Arrange
			var writeDiscreteSignalCommand = new WriteDiscreteSignalCommand(1, 1, "On");
			protocolDriverMock.Setup(x => x.WriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State)).Returns(false);

			var commandProcessor = new WriteDiscreteSignalCommandProcessor(protocolDriverMock.Object);

			//Act
			CommandResultBase result = commandProcessor.ProcessCommand(writeDiscreteSignalCommand);

			//Assert
			Assert.IsType<WriteDiscreteSignalFailedCommandResult>(result);
		}

	}
}
