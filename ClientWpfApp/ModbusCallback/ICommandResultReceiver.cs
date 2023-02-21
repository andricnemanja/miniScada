using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public interface ICommandResultReceiver
	{
		void ReceiveCommandResult(CommandResultBase commandResult);
	}
}