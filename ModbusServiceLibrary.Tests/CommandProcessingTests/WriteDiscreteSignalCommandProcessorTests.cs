using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.RtuCommands;
using Moq;
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
			protocolDriverMock.Setup(x => x.WriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State)).Returns(RtuConnectionResponse.CommandExecuted);

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
			protocolDriverMock.Setup(x => x.WriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State)).Returns(RtuConnectionResponse.CommandFailed);

			var commandProcessor = new WriteDiscreteSignalCommandProcessor(protocolDriverMock.Object);

			//Act
			CommandResultBase result = commandProcessor.ProcessCommand(writeDiscreteSignalCommand);

			//Assert
			Assert.IsType<WriteDiscreteSignalFailedCommandResult>(result);
		}

	}
}
