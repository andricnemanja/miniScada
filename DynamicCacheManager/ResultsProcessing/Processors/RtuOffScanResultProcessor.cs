using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class RtuOffScanResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public RtuOffScanResultProcessor(IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			RtuOffScanResult commandData = (RtuOffScanResult)commandResult;

			Flag offScanFlag = serviceFlagCache.GetFlag("Off Scan");
			Flag connectionFailureFlag = serviceFlagCache.GetFlag("Connection Failure");

			if (!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, offScanFlag))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, offScanFlag);
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, offScanFlag);
			}
			if (dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, connectionFailureFlag))
			{
				dynamicCacheClient.RemoveRtuFlag(commandData.RtuId, connectionFailureFlag);
				dynamicCacheClient.PublishRemovedRtuFlag(commandData.RtuId, connectionFailureFlag);
			}

		}
	}
}
