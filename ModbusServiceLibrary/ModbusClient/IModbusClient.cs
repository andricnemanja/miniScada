namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusClient
	{
		void Disconnect();
		bool TryReadCoils(int startingAddress, int numberOfCoils, out bool[] values);
		bool TryReadSingleCoil(int startingAddress, out bool value);
		bool TryReadSingleHoldingRegister(int startingAddress, out int value);
		bool TryWriteMultipleCoil(int coilAddress, bool[] data);
		bool TryWriteSingleCoil(int coilAddress, bool value);
		bool TryWriteSingleHoldingRegister(int startingAddress, int value);
	}
}