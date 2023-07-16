using System.ServiceModel;
using DynamicCacheManager.ResultsProcessing;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public sealed class DynamicCacheManagerService : IDynamicCacheManagerService
	{
		private readonly ICommandResultQueue commandResultQueue;
		public DynamicCacheManagerService(ICommandResultQueue commandResultQueue)
		{
			this.commandResultQueue = commandResultQueue;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			commandResultQueue.AddToQueue(commandResult);
		}
	}
}
