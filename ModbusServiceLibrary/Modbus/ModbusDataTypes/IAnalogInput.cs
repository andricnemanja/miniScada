using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAnalogInput : IRemotePoint
	{
		bool TryRead(IModbusClient modbusClient, out ushort readValue);
	}
}
