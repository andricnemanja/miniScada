using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ConnectToRtuResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IServiceFlagCache serviceFlagCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ConnectToRtuResultProcessor(IServiceRtuCache rtuCache, IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.serviceFlagCache = serviceFlagCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ConnectToRtuResult commandData = (ConnectToRtuResult)commandResult;

			Flag connectionFailuerFlag = serviceFlagCache.GetFlag("Connection Failure");

			if (dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, connectionFailuerFlag))
			{
				dynamicCacheClient.RemoveRtuFlag(commandData.RtuId, connectionFailuerFlag);
				dynamicCacheClient.PublishRemovedRtuFlag(commandData.RtuId, connectionFailuerFlag);
			}
		}
	}
}
