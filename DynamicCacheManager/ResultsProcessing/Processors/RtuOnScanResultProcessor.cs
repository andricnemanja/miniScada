using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class RtuOnScanResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public RtuOnScanResultProcessor(IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			RtuOnScanResult commandData = (RtuOnScanResult)commandResult;

			Flag offScanFlag = serviceFlagCache.GetFlag("Off Scan");

			if (dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, offScanFlag))
			{
				dynamicCacheClient.RemoveRtuFlag(commandData.RtuId, offScanFlag);
				dynamicCacheClient.PublishRemovedRtuFlag(commandData.RtuId, offScanFlag);
			}
		}
	}
}
