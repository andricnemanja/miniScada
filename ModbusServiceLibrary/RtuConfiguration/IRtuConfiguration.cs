using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.RtuConfiguration
{
	public interface IRtuConfiguration
	{
		RTUConnectionParameters GetRtuConnectionParameters(int rtuId);
		void InitializeData();
		List<RTU> ReadAllRTUs();
		ISignal GetSignal(int rtuId, int signalId);
	}
}