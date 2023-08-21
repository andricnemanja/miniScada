using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ReadSingleDiscreteSignalFailedResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleDiscreteSignalFailedResultProcessor(IServiceRtuCache rtuCache, IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleDiscreteSignalFailedResult commandData = (ReadSingleDiscreteSignalFailedResult)commandResult;

			Flag commandFailedFlag = serviceFlagCache.GetFlag("Command Failed");

			if (!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, commandFailedFlag))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, commandFailedFlag);
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, commandFailedFlag);
			}
		}
	}
}
