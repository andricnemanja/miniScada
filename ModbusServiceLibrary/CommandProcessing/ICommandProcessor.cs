using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public interface ICommandProcessor
	{
		CommandResultBase ProcessCommand(RtuCommandBase command);
	}
}
