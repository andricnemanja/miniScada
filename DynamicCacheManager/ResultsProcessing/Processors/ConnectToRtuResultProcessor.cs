using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ConnectToRtuResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ConnectToRtuResultProcessor(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ConnectToRtuResult commandData = (ConnectToRtuResult)commandResult;

			if(!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, "Active Connection"))
			{
				dynamicCacheClient.RemoveRtuFlag(commandData.RtuId, "Connection Failure");
				dynamicCacheClient.PublishRemovedRtuFlag(commandData.RtuId, "Connection Failure");
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, "Active Connection");
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, "Active Connection");
			}
		}
	}
}
