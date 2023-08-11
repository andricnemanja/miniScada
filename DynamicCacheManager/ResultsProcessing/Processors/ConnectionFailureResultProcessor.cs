using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ConnectionFailureResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ConnectionFailureResultProcessor(IServiceRtuCache rtuCache, IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ConnectionFailureResult commandData = (ConnectionFailureResult)commandResult;

			Flag connectionFailuerFlag = serviceFlagCache.GetFlag("Connection Failure");

			if (!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, connectionFailuerFlag))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, connectionFailuerFlag);
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, connectionFailuerFlag);
			}
		}
	}
}
