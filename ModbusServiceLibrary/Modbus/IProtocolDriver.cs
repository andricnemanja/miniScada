using System.Collections.Generic;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;

namespace ModbusServiceLibrary.Modbus
{
	public interface IProtocolDriver
	{
		List<IAnalogPoint> AnalogPoints { get; set; }
		List<IDigitalPoint> DigitalPoints { get; set; }

		void Initialize();
		double ReadAnalogSignal(int signalId);
		string ReadDiscreteSignal(int signalId);
		bool TryWriteAnalogSignal(int signalId, double newValue);
		bool TryWriteDiscreteSignal(int signalId, string newState);
		bool TryConnectToRtu(int rtuId, string rtuAddress, int port);
	}
}