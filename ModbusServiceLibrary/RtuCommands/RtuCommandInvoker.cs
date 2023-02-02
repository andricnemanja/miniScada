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
		private readonly IModelServiceReader modelServiceReader;

		public RtuCommandInvoker(ICommandReceiver commandReceiver, IModelServiceReader modelServiceReader)
		{
			this.commandReceiver = commandReceiver;
			this.modelServiceReader = modelServiceReader;
		}

		public ICommandResult ReadSingleCoil(int rtuId, int singalAddress)
		{
			DiscreteSignal discreteSignal = FindDiscreteSignal(rtuId, singalAddress);
			int numberOfCoils = (discreteSignal.SignalType == DiscreteSignalType.TwoBit) ? 2 : 1;
			return commandReceiver.ReceiveCommand(new ReadSingleCoilCommand(rtuId, singalAddress, numberOfCoils, discreteSignal.MappingId));
		}

		public ICommandResult ConnectToRtu(int rtuId)
		{
			RTU rtu = modelServiceReader.RtuList.SingleOrDefault(r => r.RTUData.ID == rtuId);
			return commandReceiver.ReceiveCommand(new ConnectToRtuCommand(rtuId, rtu.RTUData.IpAddress, rtu.RTUData.Port));
		}

		private RTU FindRtu(int rtuId)
		{
			return modelServiceReader.RtuList.SingleOrDefault(r => r.RTUData.ID == rtuId);
		}

		private DiscreteSignal FindDiscreteSignal(int rtuId, int signalAddress)
		{
			return FindRtu(rtuId).DiscreteSignalValues.SingleOrDefault(s => s.DiscreteSignal.Address == signalAddress).DiscreteSignal;
		}
	}
}
