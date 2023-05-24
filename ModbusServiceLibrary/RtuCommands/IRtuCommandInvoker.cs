using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.RtuCommands
{
	public interface IRtuCommandInvoker
	{
		CommandResultBase ConnectToRtu(int rtuId);
		CommandResultBase ReadSingleSignalCommand(int rtuId, int singalAddress);
		CommandResultBase WriteAnalogSignalCommand(int rtuId, int signalId, double valueToWrite);
		CommandResultBase WriteDiscreteSignalCommand(int rtuId, int singalId, string state);
		CommandResultBase ReadSingleSignalScheduler(RtuCommandBase command);
	}
}