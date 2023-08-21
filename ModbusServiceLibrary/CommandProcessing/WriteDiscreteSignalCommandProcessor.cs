using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class WriteDiscreteSignalCommandProcessor: ICommandProcessor
	{
		private readonly IProtocolDriver protocolDriver;

		public WriteDiscreteSignalCommandProcessor(IProtocolDriver protocolDriver)
		{
			this.protocolDriver = protocolDriver;
		}

		public CommandResultBase ProcessCommand(RtuCommandBase command)
		{
			WriteDiscreteSignalCommand writeDiscreteSignalCommand = (WriteDiscreteSignalCommand)command;
			var commandState = protocolDriver.WriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State);
			if (commandState == RtuConnectionResponse.CommandExecuted)
			{
				return new WriteDiscreteSignalCommandResult(writeDiscreteSignalCommand.RtuId);
			}
			else
			{
				return new WriteDiscreteSignalFailedCommandResult(writeDiscreteSignalCommand.RtuId, "Read-only signal");
			}

		}
	}
}
