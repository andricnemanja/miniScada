using System.Collections.Concurrent;
using System.Threading;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public class CommandResultQueue
	{
		private readonly ConcurrentQueue<CommandResultBase> commandResults = new ConcurrentQueue<CommandResultBase>();
		private readonly ManualResetEvent queueEvent;
		private readonly ICommandResultReceiver commandResultReceiver;

		public CommandResultQueue(ICommandResultReceiver commandResultReceiver)
		{
			this.commandResultReceiver = commandResultReceiver;
			queueEvent = new ManualResetEvent(false);
			Thread thread = new Thread(ProcessResults);
			thread.Start();
		}

		public void AddToQueue(CommandResultBase commandResult)
		{
			commandResults.Enqueue(commandResult);
			queueEvent.Set();
		}

		private void ProcessResults()
		{
			while (true)
			{
				queueEvent.WaitOne();

				if(commandResults.TryDequeue(out CommandResultBase nextCommandResult)) 
				{
					commandResultReceiver.ReceiveCommandResult(nextCommandResult);
				}
				else
				{
					queueEvent.Reset();
				}
			}
		}
	}
}
