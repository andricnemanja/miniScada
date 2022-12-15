namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusClient
	{
		void Disconnect();
		ushort[] ReadAnalogInputs(int startingAddress, int numberOfRegisters);
		bool[] ReadCoils(int startingAddress, int numberOfCoils);
		bool[] ReadDiscreteInputs(int startingAddress, int numberOfCoils);
		ushort[] ReadHoldingRegisters(int startingAddress, int numberOfRegisters);
		bool TryReadSingleCoil(int startingAddress, out bool value);
		bool TryReadSingleHoldingRegister(int startingAddress, out int value);
		bool TryWriteSingleCoil(int coilAddress, bool value);
		bool TryWriteSingleHoldingRegister(int startingAddress, int value);
		void WriteMultipleCoil(int coilAddress, bool[] data);
	}
}