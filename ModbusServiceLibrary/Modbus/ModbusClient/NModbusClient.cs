using ModbusServiceLibrary.ModbusConnection;

namespace ModbusServiceLibrary.ModbusClient
{
	/// <summary>
	/// Class <c>NModbusClient</c> models a Modbus client.
	/// Contains methods for commmunicating and operating with RTU.
	/// </summary>
	public sealed class NModbusClient : IModbusClient
	{
		private readonly IModbusConnectionManager modbusConnectionManager;

		public NModbusClient(IModbusConnectionManager modbusConnectionManager)
		{
			this.modbusConnectionManager = modbusConnectionManager;
		}

		/// <summary>
		/// Try to read holding registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		public bool TryReadHoldingRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).ReadHoldingRegisters(startingAddress, numberOfRegisters, out value) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Try to read input registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		public bool TryReadInputRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).ReadInputRegisters(startingAddress, numberOfRegisters, out value) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Try to write new value in the single holding register.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Value that needs to be written.</param>
		/// <returns>True if signal is successfully written, false if error occured during writing.</returns>
		public bool TryWriteSingleHoldingRegister(int rtuId, int startingAddress, int value)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).WriteSingleHoldingRegister(startingAddress, value) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Try to read values of multiple coils.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="signalValue">Read value.</param>
		/// <returns>True if coils are successfully read, false if error occured during reading.</returns>
		public bool TryReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).ReadCoils(startingAddress, numberOfCoils, out signalValue) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Try to read values of multiple inputs.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="signalValue">Read value.</param>
		/// <returns>True if coils are successfully read, false if error occured during reading.</returns>
		public bool TryReadInputs(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).ReadInputs(startingAddress, numberOfCoils, out signalValue) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Write in values for multiple coils.
		/// </summary>
		/// <param name="coilAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="valueToWrite">Value that needs to be written.</param>
		/// <returns>True if coils are successfully written, false if error occured during writing.</returns>
		public bool TryWriteCoils(int rtuId, int coilAddress, bool[] valueToWrite)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).WriteCoils(coilAddress, valueToWrite) == RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Dispose connection to RTU.
		/// </summary>
		public void Disconnect(int rtuId)
		{
			modbusConnectionManager.GetRtuConnection(rtuId).Disconnect();
		}

		public void TryConnect(int rtuId, string ipAddress, int port)
		{
			modbusConnectionManager.GetRtuConnection(rtuId).Connect(ipAddress, port);
		}
	}
}
