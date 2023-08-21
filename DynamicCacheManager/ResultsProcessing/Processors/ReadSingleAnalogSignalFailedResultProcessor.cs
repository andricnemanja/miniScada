using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ReadSingleAnalogSignalFailedResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleAnalogSignalFailedResultProcessor(IServiceRtuCache rtuCache, IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleAnalogSignalFailedResult commandData = (ReadSingleAnalogSignalFailedResult)commandResult;

			Flag commandFailedFlag = serviceFlagCache.GetFlag("Command Failed");

			if (!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, commandFailedFlag))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, commandFailedFlag);
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, commandFailedFlag);
			}
		}
	}
}
