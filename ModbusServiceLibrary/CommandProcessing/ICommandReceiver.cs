using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	public interface ICommandReceiver
	{
		CommandResultBase ReceiveCommand(RtuCommandBase command);
	}
}