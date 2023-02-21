using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public interface ICommandResultProcessor
	{
		void ProcessCommandResult(CommandResultBase commandResult);
	}
}
