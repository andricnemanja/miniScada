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
			ISignal signal = rtuCache.GetSignal(commandData.RtuId, commandData.SignalId);

			dynamicCacheClient.ChangeSignalValue(signal, commandData.State);
			dynamicCacheClient.PublishSignalChange(signal, commandData.State);
		}
	}
}
