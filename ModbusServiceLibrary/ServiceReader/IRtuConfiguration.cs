using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.ServiceReader
{
	public interface IRtuConfiguration
	{
		int GetMappingSignal(int rtuId, int signalId);
		RTUConnectionParameters GetRtuConnectionParameters(int rtuId);
		void InitializeData();
		List<RTU> ReadAllRTUs();
		ISignal GetSignal(int rtuId, int signalId);
	}
}