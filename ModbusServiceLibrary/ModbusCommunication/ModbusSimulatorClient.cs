using System.Linq;
using System.Net.Sockets;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.ServiceReader;
using NModbus;

namespace ModbusServiceLibrary.ModbusCommunication
{
	/// <summary>
	/// Class responsible for making connection with RTU and reading signal values.
	/// </summary>
	public sealed class ModbusSimulatorClient : IModbusSimulatorClient
	{
		private readonly IModelServiceReader modelServiceReader;

		/// <summary>
		/// An instance of <see cref="ModbusSimulatorClient"/> class.
		/// </summary>
		/// <param name="modelServiceReader">An instance of class <see cref="IModelServiceReader"/></param>
		public ModbusSimulatorClient(IModelServiceReader modelServiceReader)
		{
			this.modelServiceReader = modelServiceReader;
		}


		/// <summary>
		/// Try to make a connection with specific RTU.
		/// </summary>
		/// <param name="rtudId">Id of RTU to connect to.</param>
		/// <returns>True if connection is made, false if there is error that prevents connecting</returns>
		public bool TryConnectToRtu(int rtudId)
		{
			if (!TryFindRtu(rtudId, out RTU rtu))
				return false;

			try
			{
				TcpClient client = new TcpClient(rtu.RTUData.IpAddress, rtu.RTUData.Port);
				var factory = new ModbusFactory();
				IModbusMaster master = factory.CreateMaster(client);
				rtu.Connection.Client = new NModbusClient(master);
				rtu.Connection.Status = true;
				
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Try to read single register from the RTU
		/// </summary>
		/// <param name="rtuId">Id of RTU to read from</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <param name="value">Function output - value of the read signal</param>
		/// <returns>True if signal is read, false if an error occurred during reading</returns>
		public bool TryReadAnalogInput(int rtuId, int signalAddress, out int value)
		{
			value = 0;
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			AnalogSignalValue signalValue = FindAnalogSignal(rtu, signalAddress);

			lock (signalValue)
			{
				if (!rtu.Connection.Client.TryReadSingleHoldingRegister(signalAddress, out value))
				{
					return false;
				}
			}

			signalValue.Value = value;
			return true;
		}

		/// <summary>
		/// Try to read single discrete input from
		/// </summary>
		/// <param name="rtuId">Id of RTU to read from</param>
		/// <param name="signalAddress">Address of the discrete input</param>
		/// <param name="discreteValue">Function output - value of the read signal</param>
		/// <returns>True if signal is read, false if an error occurred during reading</returns>
		public bool TryReadDiscreteInput(int rtuId, int signalAddress, out byte discreteValue)
		{
			discreteValue = 0;
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			DiscreteSignalValue signalValue = FindDiscreteSignal(rtu, signalAddress);

			lock (signalValue)
			{
				if (!rtu.Connection.Client.TryReadCoils(signalAddress, signalValue.DiscreteSignal.SignalType, out discreteValue))
					return false;
			}

			signalValue.Value = discreteValue;
			return true;
		}

		/// <summary>
		/// Try to write value of the single analog signal.
		/// </summary>
		/// <param name="rtuId">Id of RTU to write to.</param>
		/// <param name="signalAddress">Address of the register.</param>
		/// <param name="value">New value.</param>
		/// <returns>True if the signal is written, false if an error occurred during writing.</returns>
		public bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			AnalogSignalValue signalValue = FindAnalogSignal(rtu, signalAddress);

			lock (signalValue)
			{
				if (!rtu.Connection.Client.TryWriteSingleHoldingRegister(signalAddress, value))
					return false;
			}

			signalValue.Value = value;
			return true;
		}

		/// <summary>
		/// Try to write value of the single discrete signal.
		/// </summary>
		/// <param name="rtuId">Id of RTU to write to.</param>
		/// <param name="signalAddress">Address of the register.</param>
		/// <param name="discreteValue">New value.</param>
		/// <returns>True if the signal is written, false if an error occurred during writing.</returns>
		public bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, byte discreteValue)
		{
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			DiscreteSignalValue signalValue = FindDiscreteSignal(rtu, signalAddress);

			lock (signalValue)
			{
				if (!rtu.Connection.Client.TryWriteCoils(signalAddress, signalValue.DiscreteSignal.SignalType, discreteValue))
					return false;
			}

			signalValue.Value = discreteValue;
			return true;
		}

		/// <summary>
		/// Find the RTU by its ID
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="rtu">Function output - RTU with <paramref name="rtuId"/> ID</param>
		/// <returns>True if RTU is found, false otherwise</returns>
		public bool TryFindRtu(int rtuId, out RTU rtu)
		{
			rtu = modelServiceReader.RtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
			return rtu != null;
		}

		/// <summary>
		/// Finds the value of the analog signal by it's address.
		/// </summary>
		/// <param name="rtu">RTU which contains that analog signal.</param>
		/// <param name="signalAddress">Address of the analog signal.</param>
		/// <returns>Value of the analog signal, an instance of the <see cref="AnalogSignalValue"/> class.</returns>
		private AnalogSignalValue FindAnalogSignal(RTU rtu, int signalAddress)
		{
			return rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == signalAddress).FirstOrDefault();
		}

		/// <summary>
		/// Finds value of the discrete signal by it's address.
		/// </summary>
		/// <param name="rtu">RTU which contains that analog signal.</param>
		/// <param name="signalAddress">Address of the analog signal.</param>
		/// <returns>Value of the analog signal, an instance of the <see cref="DiscreteSignalValue"/> class.</returns>
		private DiscreteSignalValue FindDiscreteSignal(RTU rtu, int signalAddress)
		{
			return rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == signalAddress).FirstOrDefault();
		}
	}
}
