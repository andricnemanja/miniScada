using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommunication
{
	public interface IModbusConnection
	{
		List<RTU> RtuList { get; }

		void InitializeData();
		bool TryConnectToRtu(int rtudId);
		bool TryFindRtu(int rtuId, out RTU rtu);
		bool TryReadAnalogInput(int id, int signalAddress, out int value);
		bool TryReadDiscreteInput(int id, int signalAddress, out bool value);
		bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int value);
		bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, bool value);
	}
}