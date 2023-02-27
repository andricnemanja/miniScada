using System.Collections.Concurrent;
using System.Threading;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public class CommandResultQueue
	{
		private readonly BlockingCollection<CommandResultBase> commandResults = new BlockingCollection<CommandResultBase>();
		private readonly ICommandResultReceiver commandResultReceiver;

		public CommandResultQueue(ICommandResultReceiver commandResultReceiver)
		{
			this.commandResultReceiver = commandResultReceiver;
			Thread thread = new Thread(ProcessResults);
			thread.Start();
		}

		public void AddToQueue(CommandResultBase commandResult)
		{
			commandResults.Add(commandResult);
		}

		private void ProcessResults()
		{
			while (true)
			{
				commandResultReceiver.ReceiveCommandResult(commandResults.Take());
			}
		}
	}
}
