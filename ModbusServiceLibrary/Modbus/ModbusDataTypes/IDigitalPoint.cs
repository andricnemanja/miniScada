using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IDigitalPoint : IPoint
	{
		byte Length { get; }
		byte Read(IModbusClient modbusClient);
		bool TryWrite(IModbusClient modbusClient, byte newValue);
	}
}
