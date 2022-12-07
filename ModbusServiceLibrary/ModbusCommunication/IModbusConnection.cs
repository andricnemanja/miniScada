using ModbusServiceLibrary.Model.RTU;
using System.Collections.Generic;

namespace ModbusServiceLibrary.ModbusCommunication
{
	public interface IModbusConnection
	{
		List<RTU> RtuList { get; }
		void InitializeData();
		int ReadAnalogInput(int id, int signalAddress);
		bool ReadCoil(int id, int signalAddress);
		bool ReadDiscreteInput(int id, int signalAddress);
		int ReadRegister(int id, int signalAddress);
		bool TryConnectToRtu(int rtudId);
		int WriteAnalogSignalValue(int rtuId, int signalAddress, int value);
		bool WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value);
		RTU FindRtu(int rtuId);
	}
}