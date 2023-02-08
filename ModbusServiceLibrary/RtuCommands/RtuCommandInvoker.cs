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

		public ICommandResult ReadSingleCoil(int rtuId, int singalAddress)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleCoilCommand(rtuId, singalAddress));
		}

		public ICommandResult ConnectToRtu(int rtuId)
		{
			return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId));
		}
	}
}
