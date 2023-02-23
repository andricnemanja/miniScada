namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusClient2
	{
		//void Disconnect();
		bool TryReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue);
		bool TryReadInputs(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue);
		bool TryConnect(int rtuId, string rtuAddress, int rtuPort);
		bool TryReadHoldingRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value);
		/// <summary>
		/// Try to read input registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		bool TryReadInputRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value);
		bool TryWriteSingleHoldingRegister(int rtuId, int startingAddress, int value);
		bool TryWriteCoils(int rtuId, int coilAddress,  bool[] valueToWrite);
		//bool TryReadSingleHoldingRegister(int startingAddress, out int value);
		//bool TryWriteCoils(int coilAddress, DiscreteSignalType discreteSignalType, byte valueToWrite);
	}
}