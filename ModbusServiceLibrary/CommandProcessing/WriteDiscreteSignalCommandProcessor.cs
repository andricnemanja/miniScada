using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
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

			if (protocolDriver.TryWriteDiscreteSignal(writeDiscreteSignalCommand.SignalId, writeDiscreteSignalCommand.State))
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
