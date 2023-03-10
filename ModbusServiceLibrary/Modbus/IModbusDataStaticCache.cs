using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.Modbus
{
	public interface IModbusDataStaticCache
	{
		IAnalogPoint FindAnalogPoint(int signalId);
		IDigitalPoint FindDiscretePoint(int signalId);
		void Initialize();

		RTU GetRTU(int rtuId);
	}
}