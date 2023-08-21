using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IDigitalPoint : IPoint
	{
		byte Length { get; }
		RtuConnectionResponse Read(IModbusClient modbusClient, out byte readValue);
		RtuConnectionResponse Write(IModbusClient modbusClient, byte newValue);
	}
}
