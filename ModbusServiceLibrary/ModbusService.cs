using System.ServiceModel;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public sealed class ModbusService : IModbusDuplex
	{
		private readonly IModbusSimulatorClient modbusSimulatorClient;
		private readonly IModbusCommandInvoker modbusCommandInvoker;
		private readonly IValueConverter valueConverter;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusService"/>
		/// </summary>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class</param>
		/// <param name="modbusCommandInvoker">Instance of the <see cref="IModbusCommandInvoker"/> class</param>
		/// <param name="valueConverter">Instance of the <see cref="IValueConverter"/> class</param>

		public ModbusService(IModbusSimulatorClient modbusSimulatorClient, IModbusCommandInvoker modbusCommandInvoker, IValueConverter valueConverter)
		{
			this.modbusSimulatorClient = modbusSimulatorClient;
			this.modbusCommandInvoker = modbusCommandInvoker;
			this.valueConverter = valueConverter;
		}

		/// <summary>
		/// Read value of the analog signal from the RTU.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			if(modbusCommandInvoker.TryReadAnalogSignalValue(rtuId, signalAddress, out int value))
			{
				int realValue = valueConverter.ConvertToRealValue(rtuId, signalAddress, value);
				string unit = valueConverter.GetSignalUnit(rtuId, signalAddress);
				callback.UpdateAnalogSignalValue(rtuId, signalAddress, realValue,  unit);
			}

			else
				callback.ChangeConnectionStatusToFalse(rtuId);
			
		}

		/// <summary>
		/// Read value of the discrete signal from the RTU.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			if(modbusCommandInvoker.TryReadDiscreteSignalValue(rtuId, signalAddress, out bool value))
				callback.UpdateDiscreteSignalValue(rtuId, signalAddress, value);
			else
				callback.ChangeConnectionStatusToFalse(rtuId);
		}

		/// <summary>
		/// Write new analog value.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the analog signal.</param>
		public void WriteAnalogSignal(int rtuId, int signalAddress, int newValue)
		{
			int convertedValue = valueConverter.ConvertToSensorValue(rtuId, signalAddress, newValue);
			if(!modbusCommandInvoker.TryWriteAnalogSignalValue(rtuId, signalAddress, convertedValue))
			{
				IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
				callback.ChangeConnectionStatusToFalse(rtuId);
			}
		}

		/// <summary>
		/// Write new discrete value.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the discrete signal.</param>
		public void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue)
		{
			if(!modbusCommandInvoker.TryWriteDiscreteSignalValue(rtuId, signalAddress, newValue))
			{
				IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
				callback.ChangeConnectionStatusToFalse(rtuId);
			}
		}

		/// <summary>
		/// Make a connection with the RTU.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <returns>True value if the connection is made.</returns>
		public bool TryConnectToRtu(int rtuId)
		{
			return modbusSimulatorClient.TryConnectToRtu(rtuId);
		}
	}
}
