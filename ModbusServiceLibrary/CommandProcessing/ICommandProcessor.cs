using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.CommandProcessing
{
	public interface ICommandProcessor
	{
		ICommandResult ProcessCommand(object command);
	}
}
