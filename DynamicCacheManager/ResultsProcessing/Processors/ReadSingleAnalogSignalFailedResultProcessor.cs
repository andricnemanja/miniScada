using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ReadSingleAnalogSignalFailedResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleAnalogSignalFailedResultProcessor(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleAnalogSignalFailedResult commandData = (ReadSingleAnalogSignalFailedResult)commandResult;

			if(!dynamicCacheClient.DoesRtuHaveFlag(commandData.RtuId, "Connection Failure"))
			{
				dynamicCacheClient.AddRtuFlag(commandData.RtuId, "Connection Failure");
				dynamicCacheClient.PublishNewRtuFlag(commandData.RtuId, "Connection Failure");
				dynamicCacheClient.RemoveRtuFlag(commandData.RtuId, "Active Connection");
				dynamicCacheClient.PublishRemovedRtuFlag(commandData.RtuId, "Active Connection");
			}
		}
	}
}
