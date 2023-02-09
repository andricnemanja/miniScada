using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;
using System.Windows.Input;

namespace ModbusServiceLibrary.CommandProcessing
{
	public interface ICommandProcessor
	{
		CommandResultBase ProcessCommand(IRtuCommand command);
	}
}
