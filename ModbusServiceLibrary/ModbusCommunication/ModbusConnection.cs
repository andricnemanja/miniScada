using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceLibrary.ModbusCommunication
{
	/// <summary>
	/// Class responsible for making connection with RTU. Contains various functionalities with connected RTU.
	/// </summary>
	public sealed class ModbusConnection : IModbusConnection
	{
		private readonly IModelServiceReader modelServiceReader;

		/// <summary>
		/// An instance of <see cref="ModbusConnection"/> class.
		/// </summary>
		/// <param name="modelServiceReader">An instance of class <see cref="IModelServiceReader"/></param>
		public ModbusConnection(IModelServiceReader modelServiceReader)
		{
			this.modelServiceReader = modelServiceReader;
		}

		/// <summary>
		/// List of RTUs.
		/// </summary>
		public List<RTU> RtuList { get; private set; }

		/// <summary>
		/// Initialize static data by reading all of RTUs
		/// </summary>
		public void InitializeData()
		{
			RtuList = modelServiceReader.ReadAllRTUs();
		}

		/// <summary>
		/// Make a connection with specific RTU
		/// </summary>
		/// <param name="rtudId">Number specific to the RTU</param>
		/// <returns></returns>
		public bool TryConnectToRtu(int rtudId)
		{
			if (!TryFindRtu(rtudId, out RTU rtu))
				return false;

			try
			{
				rtu.Connection.Client = new NModbusClient(rtu.RTUData.IpAddress, rtu.RTUData.Port);
				rtu.Connection.Status = true;
				
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Read single register from the RTU
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <returns>Returns the value of the register</returns>
		public bool TryReadAnalogInput(int id, int signalAddress, out int value)
		{
			value = 0;
			if (!TryFindRtu(id, out RTU rtu))
				return false;

			if (!rtu.Connection.Client.TryReadSingleHoldingRegister(signalAddress, out value))
				return false;

			FindAnalogSignal(rtu, signalAddress).Value = value;
			return true;
		}

		/// <summary>
		/// Read single discrete input from the simulator
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the discrete input</param>
		/// <returns>Returns the value of the discrete input</returns>
		public bool TryReadDiscreteInput(int id, int signalAddress, out bool value)
		{
			value = false;
			if (!TryFindRtu(id, out RTU rtu))
				return false;

			if (!rtu.Connection.Client.TryReadSingleCoil(signalAddress, out value))
				return false;

			FindDiscreteSignal(rtu, signalAddress).Value = value;
			return true;
		}

		/// <summary>
		/// Write value of the single analog signal 
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <param name="value">Updated value</param>
		/// <returns>Updated value</returns>
		public bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			if (!rtu.Connection.Client.TryWriteSingleHoldingRegister(signalAddress, value))
				return false;

			FindAnalogSignal(rtu, signalAddress).Value = value;
			return true;
		}

		/// <summary>
		/// Write value of the single discrete signal
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <param name="value">Updated value</param>
		/// <returns>Updated value</returns>
		public bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, bool value)
		{
			if (!TryFindRtu(rtuId, out RTU rtu))
				return false;

			if (!rtu.Connection.Client.TryWriteSingleCoil(signalAddress, value))
				return false;

			FindDiscreteSignal(rtu, signalAddress).Value = value;
			return true;
		}

		/// <summary>
		/// Find the RTU by its ID
		/// </summary>
		/// <param name="rtuId">Number specific to the RTU</param>
		/// <returns>RTU</returns>
		public bool TryFindRtu(int rtuId, out RTU rtu)
		{
			rtu = RtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
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
