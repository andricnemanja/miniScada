using ModbusServiceLibrary.Modbus.ModbusDataTypes;

namespace ModbusServiceLibrary.Modbus
{
	public interface IModbusDataStaticCache
	{
		IAnalogPoint FindAnalogPoint(int signalId);
		IDigitalPoint FindDiscretePoint(int signalId);
		void Initialize();
	}
}