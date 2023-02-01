using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	public interface ICommandReceiver
	{
		ICommandResult ReceiveCommand(IRtuCommand command);
	}
}