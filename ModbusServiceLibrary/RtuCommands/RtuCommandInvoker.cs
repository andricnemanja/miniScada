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

		public CommandResultBase ReadSingleSignalCommand(int rtuId, int singalAddress)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleSignalCommand(rtuId, singalAddress));
		}

		public CommandResultBase ConnectToRtu(int rtuId)
		{
			return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId));
		}
	}
}
