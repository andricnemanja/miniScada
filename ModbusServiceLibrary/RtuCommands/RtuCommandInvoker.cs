using System.Linq;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceLibrary.RtuCommands
{
	public class RtuCommandInvoker : IRtuCommandInvoker
	{
		private readonly ICommandReceiver commandReceiver;

		public RtuCommandInvoker(ICommandReceiver commandReceiver, IModelServiceReader modelServiceReader)
		{
			this.commandReceiver = commandReceiver;
		}

		public ICommandResult ReadSingleCoil(int rtuId, int signalId)
		{
			return commandReceiver.ReceiveCommand(new ReadSingleCoilCommand(rtuId, signalId));
		}

		public ICommandResult WriteSingleCoil(int rtuId, int signalId, string state)
		{
			return commandReceiver.ReceiveCommand(new WriteSingleCoilCommand(rtuId, signalId, state));
		}

		//public ICommandResult ConnectToRtu(int rtuId)
		//{
		//	RTU rtu = modelServiceReader.RtuList.SingleOrDefault(r => r.RTUData.ID == rtuId);
		//	return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId, rtu.RTUData.IpAddress, rtu.RTUData.Port));
		//}

	}
}
