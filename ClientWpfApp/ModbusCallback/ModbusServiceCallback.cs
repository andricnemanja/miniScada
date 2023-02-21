using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	[CallbackBehavior(UseSynchronizationContext = false)]
	public sealed class ModbusServiceCallback : ModbusServiceReference.IModbusDuplexCallback
	{
		private readonly CommandResultQueue commandResultQueue;

		public ModbusServiceCallback(CommandResultQueue commandResultQueue)
		{
			this.commandResultQueue = commandResultQueue;
		}

		public void ReceiveCommandResult(CommandResultBase commandResult)
		{
			commandResultQueue.AddToQueue(commandResult);
		}
	}
}
