using ModbusServiceLibrary.Data;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusCommunication
{
	public class ModbusWriter : IModbusWriter
	{
		private readonly IRtuDataList rtuDataList;

		public ModbusWriter(IRtuDataList rtuDataList)
		{
			this.rtuDataList = rtuDataList;
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, int value)
		{
			RTU rtu = FindRtu(rtuId);
			rtu.Connection.Client.WriteSingleRegister(signalAddress, value);
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value)
		{
			RTU rtu = FindRtu(rtuId);
			rtu.Connection.Client.WriteSingleCoil(signalAddress, value);
		}

		private RTU FindRtu(int rtuId)
		{
			return rtuDataList.RtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}
	}
}
