using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class WriteAnalogSignalCommandProcessor : ICommandProcessor
	{
		private readonly IProtocolDriver protocolDriver;

		public WriteAnalogSignalCommandProcessor(IProtocolDriver protocolDriver)
		{
			this.protocolDriver = protocolDriver;
		}

		public CommandResultBase ProcessCommand(RtuCommandBase command)
		{
			WriteAnalogSignalCommand writeAnalogSignalCommand = (WriteAnalogSignalCommand)command;
			var commandState = protocolDriver.WriteAnalogSignal(writeAnalogSignalCommand.SignalId, writeAnalogSignalCommand.ValueToWrite);
			if (commandState == RtuConnectionResponse.CommandExecuted)
			{
				return new WriteAnalogSignalCommandResult(writeAnalogSignalCommand.RtuId);
			}
			else
			{
				return new WriteAnalogSignalFailedCommandResult(writeAnalogSignalCommand.RtuId, "Read-only signal");
			}
		}
	}
}
