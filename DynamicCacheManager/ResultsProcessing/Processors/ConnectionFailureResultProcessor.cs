using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ConnectionFailureResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ConnectionFailureResultProcessor(IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ConnectionFailureResult commandData = (ConnectionFailureResult)commandResult;

			Flag offScanFlag = serviceFlagCache.GetFlag("Off Scan");
			Flag connectionFailuerFlag = serviceFlagCache.GetFlag("Connection Failure");

			if (!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, connectionFailuerFlag) && !dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, offScanFlag))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, connectionFailuerFlag);
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, connectionFailuerFlag);
			}
		}
	}
}
