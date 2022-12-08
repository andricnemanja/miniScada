using System.ServiceModel;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;


namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class ModbusService : IModbusDuplex
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

		/// <summary>
		/// Read value of the analog signal from the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			int newValue = modbusCommandInvoker.ReadAnalogSignalValue(rtuId, signalAddress);
			callback.UpdateAnalogSignalValue(rtuId, signalAddress, newValue);
		}

		/// <summary>
		/// Read value of the discrete signal from the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			bool newValue = modbusCommandInvoker.ReadDiscreteSignalValue(rtuId, signalAddress);
			callback.UpdateDiscreteSignalValue(rtuId, signalAddress, newValue);
		}

		/// <summary>
		/// Write new analog value
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		/// <param name="newValue">New value of the analog signal</param>
		public void WriteAnalogSignal(int rtuId, int signalAddress, int newValue)
		{
			modbusCommandInvoker.WriteAnalogSignalValue(rtuId, signalAddress, newValue);
		}

		/// <summary>
		/// Write new discrete value
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		/// <param name="newValue">New value of the discrete signal</param>
		public void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue)
		{
			modbusCommandInvoker.WriteDiscreteSignalValue(rtuId, signalAddress, newValue);
		}

		/// <summary>
		/// Make a connection with the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <returns>True value if the connection is made</returns>
		public bool TryConnectToRtu(int rtuId)
		{
			return modbusConnection.TryConnectToRtu(rtuId);
		}
	}
}
