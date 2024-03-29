﻿using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus.ModbusClient
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
		public RtuConnectionResponse ReadHoldingRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteReadCommand(connection.ModbusMaster.ReadHoldingRegisters, (ushort)startingAddress, (ushort)numberOfRegisters, out value);
		}

		/// <summary>
		/// Try to read input registers from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		public RtuConnectionResponse ReadInputRegisters(int rtuId, int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteReadCommand(connection.ModbusMaster.ReadInputRegisters, (ushort)startingAddress, (ushort)numberOfRegisters, out value);
		}


		/// <summary>
		/// Try to read values of multiple coils.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="signalValue">Read value.</param>
		/// <returns>True if coils are successfully read, false if error occured during reading.</returns>
		public RtuConnectionResponse ReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteReadCommand(connection.ModbusMaster.ReadCoils, (ushort)startingAddress, (ushort)numberOfCoils, out signalValue);
		}

		/// <summary>
		/// Try to read values of multiple inputs.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="signalValue">Read value.</param>
		/// <returns>True if coils are successfully read, false if error occured during reading.</returns>
		public RtuConnectionResponse ReadInputs(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteReadCommand(connection.ModbusMaster.ReadInputs, (ushort)startingAddress, (ushort)numberOfCoils, out signalValue);
		}

		/// <summary>
		/// Try to write new value in the single holding register.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Value that needs to be written.</param>
		/// <returns>True if signal is successfully written, false if error occured during writing.</returns>
		public RtuConnectionResponse WriteSingleHoldingRegister(int rtuId, int startingAddress, int value)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteWriteCommand(connection.ModbusMaster.WriteSingleRegister, (ushort)startingAddress, (ushort)value);
		}

		/// <summary>
		/// Write in values for multiple coils.
		/// </summary>
		/// <param name="coilAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="valueToWrite">Value that needs to be written.</param>
		/// <returns>True if coils are successfully written, false if error occured during writing.</returns>
		public RtuConnectionResponse WriteCoils(int rtuId, int coilAddress, bool[] valueToWrite)
		{
			var connection = modbusConnectionManager.GetRtuConnection(rtuId);

			return connection.ExecuteWriteCommand(connection.ModbusMaster.WriteMultipleCoils, (ushort)coilAddress, valueToWrite);
		}

		/// <summary>
		/// Dispose connection to RTU.
		/// </summary>
		public RtuConnectionResponse Disconnect(int rtuId)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).Disconnect();
		}

		public RtuConnectionResponse Connect(int rtuId, string ipAddress, int port)
		{
			return modbusConnectionManager.GetRtuConnection(rtuId).Connect(ipAddress, port);
		}
	}
}
