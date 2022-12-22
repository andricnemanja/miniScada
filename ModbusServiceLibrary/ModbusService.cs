using System.ServiceModel;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;


namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public sealed class ModbusService : IModbusDuplex
	{
		private readonly IModbusSimulatorClient modbusSimulatorClient;
		private readonly IModbusCommandInvoker modbusCommandInvoker;

		public ModbusService(IModbusSimulatorClient modbusSimulatorClient, IModbusCommandInvoker modbusCommandInvoker)
		{
			this.modbusSimulatorClient = modbusSimulatorClient;
			this.modbusCommandInvoker = modbusCommandInvoker;
		}

		/// <summary>
		/// Read value of the analog signal from the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			if(modbusCommandInvoker.TryReadAnalogSignalValue(rtuId, signalAddress, out int value))
				callback.UpdateAnalogSignalValue(rtuId, signalAddress, value);
			else
				callback.ChangeConnectionStatusToFalse(rtuId);
			
		}

		/// <summary>
		/// Read value of the discrete signal from the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			if(modbusCommandInvoker.TryReadDiscreteSignalValue(rtuId, signalAddress, out bool value))
				callback.UpdateDiscreteSignalValue(rtuId, signalAddress, value);
			else
				callback.ChangeConnectionStatusToFalse(rtuId);
		}

		/// <summary>
		/// Write new analog value
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		/// <param name="newValue">New value of the analog signal</param>
		public void WriteAnalogSignal(int rtuId, int signalAddress, int newValue)
		{
			if(!modbusCommandInvoker.TryWriteAnalogSignalValue(rtuId, signalAddress, newValue))
			{
				IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
				callback.ChangeConnectionStatusToFalse(rtuId);
			}
		}

		/// <summary>
		/// Write new discrete value
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the signal</param>
		/// <param name="newValue">New value of the discrete signal</param>
		public void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue)
		{
			if(!modbusCommandInvoker.TryWriteDiscreteSignalValue(rtuId, signalAddress, newValue))
			{
				IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
				callback.ChangeConnectionStatusToFalse(rtuId);
			}
		}

		/// <summary>
		/// Make a connection with the RTU
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <returns>True value if the connection is made</returns>
		public bool TryConnectToRtu(int rtuId)
		{
			return modbusSimulatorClient.TryConnectToRtu(rtuId);
		}
	}
}
