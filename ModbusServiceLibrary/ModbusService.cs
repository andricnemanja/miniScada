using System.ServiceModel;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
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
				double realValue = valueConverter.ConvertAnalogSignalToRealValue(rtuId, signalAddress, value);
				callback.UpdateAnalogSignalValue(rtuId, signalAddress, realValue);
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
			if(modbusCommandInvoker.TryReadDiscreteSignalValue(rtuId, signalAddress, out bool[] value))
			{
				string convertedValue = valueConverter.ConvertDiscreteSignalToRealValue(rtuId, signalAddress, value);
				callback.UpdateDiscreteSignalValue(rtuId, signalAddress, convertedValue);
			}
			else
				callback.ChangeConnectionStatusToFalse(rtuId);
		}

		/// <summary>
		/// Write new analog value.
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the analog signal.</param>
		public void WriteAnalogSignal(int rtuId, int signalAddress, double newValue)
		{
			int convertedValue = valueConverter.ConvertRealValueToAnalogSignal(rtuId, signalAddress, newValue);
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
		public void WriteDiscreteSignal(int rtuId, int signalAddress, string newValue)
		{
			bool[] convertedValue = valueConverter.ConvertRealValueToDiscreteSignal(rtuId, signalAddress, newValue);
			if(!modbusCommandInvoker.TryWriteDiscreteSignalValue(rtuId, signalAddress, convertedValue))
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
