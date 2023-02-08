using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public interface ICommandProcessor
	{
		ICommandResult ProcessCommand(IRtuCommand command);
	}
}
