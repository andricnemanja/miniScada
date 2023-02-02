using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.RtuCommands
{
	public interface IRtuCommandInvoker
	{
		ICommandResult ConnectToRtu(int rtuId);
		ICommandResult ReadSingleCoil(int rtuId, int singalAddress);
	}
}