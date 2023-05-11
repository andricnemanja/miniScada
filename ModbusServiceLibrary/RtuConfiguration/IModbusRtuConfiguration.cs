using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.RtuConfiguration
{
	public interface IModbusRtuConfiguration
	{
		RTUConnectionParameters GetRtuConnectionParameters(int rtuId);
		void InitializeData();
		List<ModbusRTU> ReadAllRTUs();
		IModbusSignal GetSignal(int rtuId, int signalId);
	}
}