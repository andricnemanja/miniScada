using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAnalogPoint : IPoint
	{
		RtuConnectionResponse Read(IModbusClient modbusClient, out ushort readValue);
		RtuConnectionResponse Write(IModbusClient modbusClient, int newValue);
	}
}
