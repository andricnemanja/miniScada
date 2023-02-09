using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary.RtuCommands
{
	public class RtuCommandInvoker : IRtuCommandInvoker
	{
		private readonly ICommandReceiver commandReceiver;

		public RtuCommandInvoker(ICommandReceiver commandReceiver)
		{
			this.commandReceiver = commandReceiver;
		}

		public CommandResultBase ReadSingleSignalCommand(int rtuId, int signalId)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleSignalCommand(rtuId, signalId));
		}

		public CommandResultBase WriteAnalogSignalCommand(int rtuId, int signalId, double valueToWrite)
		{
			return commandReceiver.ReceiveCommand(new WriteAnalogSignalCommand(rtuId, signalId, valueToWrite));
		}

		public CommandResultBase ConnectToRtu(int rtuId)
		{
			return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId));
		}

		public ICommandResult WriteSingleCoil(int rtuId, int signalId, string state)
		{
			return commandReceiver.ReceiveCommand(new WriteSingleCoilCommand(rtuId, signalId, state));
		}
	}
}
