using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.ServiceReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusCommunication
{
	public class ModbusConnection : IModbusConnection
	{
		private IModelServiceReader modelServiceReader;

		public ModbusConnection(IModelServiceReader modelServiceReader)
		{
			this.modelServiceReader = modelServiceReader;
		}

		public List<RTU> RtuList { get; private set; }


		public void InitializeData()
		{
			RtuList = modelServiceReader.ReadAllRTUs();
		}

		public bool TryConnectToRtu(int rtudId)
		{
			RTU rtu = RtuList.Where(r => r.RTUData.ID == rtudId).FirstOrDefault();
			try
			{
				if (rtu.Connection.Client == null)
				{
					rtu.Connection.Client = new NModbusClient(rtu.RTUData.IpAddress, rtu.RTUData.Port);
					rtu.Connection.Status = true;
				}
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
		public int ReadRegister(int id, int signalAddress)
		{
			RTU rtu = FindRtu(id);
			return rtu.Connection.Client.ReadSingleRegister(signalAddress);
		}

		/// <summary>
		/// Read single analog input from the RTU
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <returns>Returns the value of the analog input</returns>
		public int ReadAnalogInput(int id, int signalAddress)
		{
			RTU rtu = FindRtu(id);
			return rtu.Connection.Client.ReadAnalogInputs(signalAddress, 1)[0];
		}

		/// <summary>
		/// Read single discrete input from the simulator
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the discrete input</param>
		/// <returns>Returns the value of the discrete input</returns>
		public bool ReadDiscreteInput(int id, int signalAddress)
		{
			RTU rtu = FindRtu(id);
			return rtu.Connection.Client.ReadDiscreteInputs(signalAddress, 1)[0];
		}

		/// <summary>
		/// Read single coil from the simulator
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the coil</param>
		/// <returns>Returns the value of the coil</returns>
		public bool ReadCoil(int id, int signalAddress)
		{
			RTU rtu = FindRtu(id);
			return rtu.Connection.Client.ReadCoils(signalAddress, 1)[0];
		}


		public int WriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			RTU rtu = FindRtu(rtuId);
			rtu.Connection.Client.WriteSingleRegister(signalAddress, value);
			return value;
		}

		public bool WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value)
		{
			RTU rtu = FindRtu(rtuId);
			rtu.Connection.Client.WriteSingleCoil(signalAddress, value);
			return value;
		}

		public RTU FindRtu(int rtuId)
		{
			return RtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
