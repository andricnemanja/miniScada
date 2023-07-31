using System.ServiceModel;
using DynamicCacheManager.ResultsProcessing;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager
{
	// TODO Debug ConcurrencyMode.Multiple
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
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
