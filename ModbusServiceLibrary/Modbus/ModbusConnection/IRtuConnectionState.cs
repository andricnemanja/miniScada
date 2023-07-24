namespace ModbusServiceLibrary.ModbusConnection
{
	public interface IRtuConnectionState
	{
		RtuConnectionResponse Connect(string ipAddress, int port);
		RtuConnectionResponse Disconnect();
		RtuConnectionResponse ReadCoils(int startingAddress, int numberOfCoils, out bool[] signalValue);
		RtuConnectionResponse ReadInputs(int startingAddress, int numberOfCoils, out bool[] signalValue);
		RtuConnectionResponse ReadHoldingRegisters(int startingAddress, int numberOfRegisters, out ushort[] value);
		/// <summary>
		/// Try to read input registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		RtuConnectionResponse ReadInputRegisters(int startingAddress, int numberOfRegisters, out ushort[] value);
		RtuConnectionResponse WriteSingleHoldingRegister(int startingAddress, int value);
		RtuConnectionResponse WriteCoils(int coilAddress, bool[] valueToWrite);
	}
}