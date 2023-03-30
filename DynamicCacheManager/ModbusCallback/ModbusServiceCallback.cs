using System.ServiceModel;
using DynamicCacheManager.ResultsProcessing;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ModbusCallback
{
	[CallbackBehavior(UseSynchronizationContext = false)]
	public sealed class ModbusServiceCallback : ModbusServiceReference.IModbusDuplexCallback
	{
		private readonly ICommandResultQueue commandResultQueue;

		public ModbusServiceCallback(ICommandResultQueue commandResultQueue)
		{
			this.commandResultQueue = commandResultQueue;
		}

		public void ReceiveCommandResult(CommandResultBase commandResult)
		{
			commandResultQueue.AddToQueue(commandResult);
		}
	}
}
