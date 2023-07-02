
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public interface ICommandResultQueue
	{
		void AddToQueue(CommandResultBase commandResult);
	}
}