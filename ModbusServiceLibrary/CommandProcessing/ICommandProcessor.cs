using ModbusServiceLibrary.CommandResult;
using System.Windows.Input;

namespace ModbusServiceLibrary.CommandProcessing
{
	public interface ICommandProcessor
	{
		ICommandResult ProcessCommand(object command);
	}
}
