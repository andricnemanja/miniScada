using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;

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

			if(protocolDriver.TryWriteAnalogSignal(writeAnalogSignalCommand.SignalId, writeAnalogSignalCommand.ValueToWrite))
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
