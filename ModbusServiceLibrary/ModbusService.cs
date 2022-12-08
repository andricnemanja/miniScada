using System.ServiceModel;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;


namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public sealed class ModbusService : IModbusDuplex
	{
		private readonly IModbusDuplexCallback callback;
		private readonly IModbusConnection modbusConnection;
		private readonly IModbusCommandInvoker modbusCommandInvoker;

		public ModbusService(IModbusConnection modbusConnection, IModbusCommandInvoker modbusCommandInvoker)
		{
			callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			this.modbusConnection = modbusConnection;
			this.modbusCommandInvoker = modbusCommandInvoker;
		}

		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			int newValue = modbusCommandInvoker.ReadAnalogSignalValue(rtuId, signalAddress);
			callback.UpdateAnalogSignalValue(rtuId, signalAddress, newValue);
		}

		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			bool newValue = modbusCommandInvoker.ReadDiscreteSignalValue(rtuId, signalAddress);
			callback.UpdateDiscreteSignalValue(rtuId, signalAddress, newValue);
		}

		public void WriteAnalogSignal(int rtuId, int signalAddress, int newValue)
		{
			modbusCommandInvoker.WriteAnalogSignalValue(rtuId, signalAddress, newValue);
		}

		public void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue)
		{
			modbusCommandInvoker.WriteDiscreteSignalValue(rtuId, signalAddress, newValue);
		}

		public bool TryConnectToRtu(int rtuId)
		{
			return modbusConnection.TryConnectToRtu(rtuId);
		}
	}
}
