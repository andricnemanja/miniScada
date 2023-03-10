using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAnalogOutput : IRemotePoint
	{
		bool TryWrite(IModbusClient modbusClient, int newValue);
	}
}
