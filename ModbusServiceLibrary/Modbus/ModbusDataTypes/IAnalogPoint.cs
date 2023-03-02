using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAnalogPoint : IPoint
	{
		ushort Read(IModbusClient modbusClient);
		bool TryWrite(IModbusClient modbusClient, int newValue);
	}
}
