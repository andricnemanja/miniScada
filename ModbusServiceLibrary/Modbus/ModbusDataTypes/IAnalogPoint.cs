using ModbusServiceLibrary.Modbus.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAnalogPoint : IPoint
	{
		bool TryRead(IModbusClient modbusClient, out ushort readValue);
		bool TryWrite(IModbusClient modbusClient, int newValue);
	}
}
