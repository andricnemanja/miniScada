
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public interface ICommandResultProcessor
	{
		void ProcessCommandResult(CommandResultBase commandResult);
	}
}
