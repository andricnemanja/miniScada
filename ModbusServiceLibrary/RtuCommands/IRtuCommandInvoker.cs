using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.RtuCommands
{
	public interface IRtuCommandInvoker
	{
		CommandResultBase ConnectToRtu(int rtuId);
		CommandResultBase ReadSingleSignalCommand(int rtuId, int singalAddress);
	}
}