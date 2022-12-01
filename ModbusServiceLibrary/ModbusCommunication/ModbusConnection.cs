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
	public class ModbusConnection : IModbusConnection
	{
		private IRtuDataList rtuDataList;

		public ModbusConnection(IRtuDataList rtuDataList)
		{
			this.rtuDataList = rtuDataList;
		}

		public bool TryConnectToRtu(int rtudId)
		{
			RTU rtu = rtuDataList.RtuList.Where(r => r.RTUData.ID == rtudId).FirstOrDefault();
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
	}
}
