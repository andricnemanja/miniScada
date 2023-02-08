using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	public interface ICommandReceiver
	{
		CommandResultBase ReceiveCommand(IRtuCommand command);
	}
}