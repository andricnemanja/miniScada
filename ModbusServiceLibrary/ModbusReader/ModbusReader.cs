using ModbusServiceLibrary.Data;
using ModbusServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusReader
{
	public class ModbusReader : IModbusReader
	{
		IRtuDataList rtuDataList;

		public ModbusReader(IRtuDataList rtuDataList)
		{
			this.rtuDataList = rtuDataList;
		}

		/// <summary>
		/// Read single register from the RTU
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <returns>Returns the value of the register</returns>
		public int ReadRegister(int id, int signalAddress)
		{
			int signalValue = 0;
			foreach (RTU rtu in rtuDataList.RtuList)
			{
				if (rtu.RTUData.ID == id)
				{
					signalValue = rtu.Connection.Client.ReadSingleRegister(signalAddress);
				}
			}
			return signalValue;
		}

		/// <summary>
		/// Read single analog input from the RTU
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <returns>Returns the value of the analog input</returns>
		public int ReadAnalogInput(int id, int signalAddress)
		{
			int signalValue = 0;
			foreach (RTU rtu in rtuDataList.RtuList)
			{
				if (rtu.RTUData.ID == id)
				{
					signalValue = rtu.Connection.Client.ReadAnalogInputs(signalAddress, 1)[0];
				}
			}
			return signalValue;
		}

		/// <summary>
		/// Read single discrete input from the simulator
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the discrete input</param>
		/// <returns>Returns the value of the discrete input</returns>
		public bool ReadDiscreteInput(int id, int signalAddress)
		{
			bool signalValue = false;
			foreach (RTU rtu in rtuDataList.RtuList)
			{
				if (rtu.RTUData.ID == id)
				{
					signalValue = rtu.Connection.Client.ReadDiscreteInputs(signalAddress, 1)[0];
				}
			}
			return signalValue;
		}

		/// <summary>
		/// Read single coil from the simulator
		/// </summary>
		/// <param name="id">Number specific to the RTU</param>
		/// <param name="signalAddress">Address of the coil</param>
		/// <returns>Returns the value of the coil</returns>
		public bool ReadCoil(int id, int signalAddress)
		{
			bool signalValue = false;
			foreach (RTU rtu in rtuDataList.RtuList)
			{
				if (rtu.RTUData.ID == id)
				{
					signalValue = rtu.Connection.Client.ReadCoils(signalAddress, 1)[0];
				}
			}
			return signalValue;
		}

	}
}
