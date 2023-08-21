using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ReadSingleDiscreteSignalResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleDiscreteSignalResultProcessor(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleDiscreteSignalResult commandData = (ReadSingleDiscreteSignalResult)commandResult;

			if (commandData.State != dynamicCacheClient.GetSignalValue(commandData.RtuId, commandData.SignalId))
			{
				dynamicCacheClient.ChangeSignalValue(commandData.RtuId, commandData.SignalId, commandData.State);
				dynamicCacheClient.PublishSignalChange(commandData.RtuId, commandData.SignalId, typeof(DiscreteSignal).Name, commandData.State);
			}
		}
	}
}
