using NModbus;

namespace ModbusServiceLibrary.ModbusConnection
{
	public class RtuConnection
	{
		public RtuConnection()
		{
			ConnectionState = new DisconnectedRtuState(this);
		}

		public string IpAddress { get; set; }
		public int Port { get; set; }
		public IModbusMaster ModbusMaster { get; set; }
		public IRtuConnectionState ConnectionState { get; set; }

		public RtuConnectionResponse Connect(string ipAddress, int port) => ConnectionState.Connect(ipAddress, port);

		public RtuConnectionResponse Disconnect() => ConnectionState.Disconnect();

		public RtuConnectionResponse ReadCoils(int startingAddress, int numberOfCoils, out bool[] signalValue) => ConnectionState.ReadCoils(startingAddress, numberOfCoils, out signalValue);

		public RtuConnectionResponse ReadInputs(int startingAddress, int numberOfCoils, out bool[] signalValue) => ConnectionState.ReadInputs(startingAddress, numberOfCoils, out signalValue);

		public RtuConnectionResponse ReadHoldingRegisters(int startingAddress, int numberOfRegisters, out ushort[] value) => ConnectionState.ReadHoldingRegisters(startingAddress, numberOfRegisters, out value);

		/// <summary>
		/// Try to read input registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		public RtuConnectionResponse ReadInputRegisters(int startingAddress, int numberOfRegisters, out ushort[] value) =>
			ConnectionState.ReadInputRegisters(startingAddress, numberOfRegisters, out value);

		public RtuConnectionResponse WriteSingleHoldingRegister(int startingAddress, int value) => ConnectionState.WriteSingleHoldingRegister(startingAddress, value);

		public RtuConnectionResponse WriteCoils(int coilAddress, bool[] valueToWrite) => ConnectionState.WriteCoils(coilAddress, valueToWrite);
	}
}
