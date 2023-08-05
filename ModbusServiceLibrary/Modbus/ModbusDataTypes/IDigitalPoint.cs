using ModbusServiceLibrary.Modbus.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IDigitalPoint : IPoint
	{
		byte Length { get; }
		bool TryRead(IModbusClient modbusClient, out byte readValue);
		bool TryWrite(IModbusClient modbusClient, byte newValue);
	}
}
