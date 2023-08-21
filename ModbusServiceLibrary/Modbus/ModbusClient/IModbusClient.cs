using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus.ModbusClient
{
	public interface IModbusClient
	{
		RtuConnectionResponse ReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue);
		RtuConnectionResponse ReadInputs(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue);
		RtuConnectionResponse ReadHoldingRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value);
		RtuConnectionResponse ReadInputRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value);
		RtuConnectionResponse WriteSingleHoldingRegister(int rtuId, int startingAddress, int value);
		RtuConnectionResponse WriteCoils(int rtuId, int coilAddress,  bool[] valueToWrite);
		RtuConnectionResponse Connect(int rtuId, string ipAddress, int port);
		RtuConnectionResponse Disconnect(int rtudId);
	}
}