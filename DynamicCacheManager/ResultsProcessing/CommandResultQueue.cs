using System.Collections.Concurrent;
using System.Threading.Tasks;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public class CommandResultQueue : ICommandResultQueue
	{
		private readonly BlockingCollection<CommandResultBase> commandResults = new BlockingCollection<CommandResultBase>();
		private readonly ICommandResultReceiver commandResultReceiver;

		public CommandResultQueue(ICommandResultReceiver commandResultReceiver)
		{
			this.commandResultReceiver = commandResultReceiver;
			Task.Run(() => ProcessResults());
		}

		public void AddToQueue(CommandResultBase commandResult)
		{
			commandResults.Add(commandResult);
		}

		private void ProcessResults()
		{
			//TODO Add cancellation token
			while (true)
			{
				commandResultReceiver.ReceiveCommandResult(commandResults.Take());
			}
		}
	}
}
