using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Class that contains all the methods that send a certain command to the <see cref="CommandReceiver"/>.
	/// </summary>
	public class RtuCommandInvoker : IRtuCommandInvoker
	{
		private readonly ICommandReceiver commandReceiver;

		/// <summary>
		/// Creates new instance of the <see cref="RtuCommandInvoker"/> class.
		/// </summary>
		/// <param name="commandReceiver"></param>
		public RtuCommandInvoker(ICommandReceiver commandReceiver)
		{
			this.commandReceiver = commandReceiver;
		}

		/// <summary>
		/// Sends command that reads single signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the signal.</param>
		/// <returns>Result of the command.</returns>
		public CommandResultBase ReadSingleSignalCommand(int rtuId, int signalId)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleSignalCommand(rtuId, signalId));
		}

		/// <summary>
		/// Sends command that writes new value of the analog signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the signal.</param>
		/// <param name="valueToWrite">Value that needs to be written.</param>
		/// <returns>Result of the command.</returns>
		public CommandResultBase WriteAnalogSignalCommand(int rtuId, int signalId, double valueToWrite)
		{
			return commandReceiver.ReceiveCommand(new WriteAnalogSignalCommand(rtuId, signalId, valueToWrite));
		}
		
		/// <summary>
		/// Sends command responsible for the connection to the RTU.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <returns>Result of the command.</returns>
		public CommandResultBase ConnectToRtu(int rtuId)
		{
			return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId));
		}

		/// <summary>
		/// Sends command that writes new state of the discrete signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the signal.</param>
		/// <param name="state">New state of the discrete signal.</param>
		/// <returns>Result of the command.</returns>
		public CommandResultBase WriteDiscreteSignalCommand(int rtuId, int signalId, string state)
		{
			return commandReceiver.ReceiveCommand(new WriteDiscreteSignalCommand(rtuId, signalId, state));
		}

		/// <summary>
		/// Forwards the command sent from the Scheduler service to the command processor. It is responsible for the reading of the single signal.
		/// </summary>
		/// <param name="command">Command sent from the Scheduler service.</param>
		/// <returns>Result of the command.</returns>
		public CommandResultBase ReadSingleSignalScheduler(RtuCommandBase command)
		{
			return commandReceiver.ReceiveCommand(command);
		}
	}
}
