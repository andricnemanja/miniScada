using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public interface ICommandResultReceiver
	{
		void ReceiveCommandResult(CommandResultBase commandResult);
	}
}