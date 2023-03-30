using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public class ReadSingleDiscreteSignalResultProcessor : ICommandResultProcessor
	{
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleDiscreteSignalResultProcessor(IDynamicCacheClient dynamicCacheClient)
		{
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleDiscreteSignalResult readCommandResult = (ReadSingleDiscreteSignalResult)commandResult;

			dynamicCacheClient.ChangeSignalValue(readCommandResult.RtuId, readCommandResult.SignalId, readCommandResult.State);
		}
	}
}
