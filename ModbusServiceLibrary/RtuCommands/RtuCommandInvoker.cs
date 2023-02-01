using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceLibrary.RtuCommands
{
	public class RtuCommandInvoker
	{
		private readonly ICommandReceiver commandReceiver;
		private readonly IModelServiceReader modelServiceReader;
		public ICommandResult ReadSingleCoil(int rtuId, int singalAddress)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleCoilCommand(rtuId, singalAddress));
		}
	}
}
