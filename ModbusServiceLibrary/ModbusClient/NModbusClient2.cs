using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using ModbusServiceLibrary.Model.Signals;
using NModbus;

namespace ModbusServiceLibrary.ModbusClient
{
	/// <summary>
	/// Class <c>NModbusClient</c> models a Modbus client.
	/// Contains methods for commmunicating and operating with RTU.
	/// </summary>
	public sealed class NModbusClient2 : IModbusClient2
	{
		private List<RtuConnection> rtuConnections = new List<RtuConnection>();
		private ModbusFactory modbusFactory = new ModbusFactory();
		public bool TryConnect(int rtuId, string IpAdrress, int port)
		{
			try
			{
				TcpClient client = new TcpClient(IpAdrress, port);
				IModbusMaster master = modbusFactory.CreateMaster(client);
				rtuConnections.Add(new RtuConnection() { RtuId = rtuId, modbusMaster = master });
			}
			catch
			{
				return false;
			}
			return true;
		}


		/// <summary>
		/// Try to read single holding register from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Output read value.</param>
		/// <returns>True if signal is successfully read, false if error occured during reading.</returns>
		/*public bool TryReadSingleHoldingRegister(int startingAddress, out int value)
		{
			try
			{
				value = master.ReadHoldingRegisters(1, (ushort)startingAddress, 1)[0];
				return true;
			}
			catch
			{
				value = 0;
				return false;
			}
		}*/

		/// <summary>
		/// Try to write new value in the single holding register.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Value that needs to be written.</param>
		/// <returns>True if signal is successfully written, false if error occured during writing.</returns>
		/*public bool TryWriteSingleHoldingRegister(int startingAddress, int value)
		{
			try
			{
				master.WriteSingleRegister(1, (ushort)startingAddress, (ushort)value);
				return true;
			}
			catch
			{
				return false;
			}

		}*/

		/// <summary>
		/// Try to read values of multiple coils.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="signalValue">Read value.</param>
		/// <returns>True if coils are successfully read, false if error occured during reading.</returns>
		public bool TryReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			try
			{
				signalValue = GetRtuConnection(rtuId).modbusMaster.ReadCoils(1, (ushort)startingAddress, (ushort)numberOfCoils);
			}
			catch
			{
				signalValue = null;
				return false;
			}
			return true;
		}

		/// <summary>
		/// Write in values for multiple coils.
		/// </summary>
		/// <param name="coilAddress">Address of the RTU.</param>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="valueToWrite">Value that needs to be written.</param>
		/// <returns>True if coils are successfully written, false if error occured during writing.</returns>
		/*public bool TryWriteCoils(int coilAddress, DiscreteSignalType discreteSignalType, byte valueToWrite)
		{
			try
			{
				master.WriteMultipleCoils(1, (ushort)coilAddress, ByteToBoolArray(discreteSignalType, valueToWrite));
				return true;
			}
			catch
			{
				return false;
			}
		}*/

		/// <summary>
		/// Dispose connection to RTU.
		/// </summary>
		public void Disconnect(int rtuId)
		{
			GetRtuConnection(rtuId).modbusMaster.Dispose();
		}

		/// <summary>
		/// Converts array of bools that is read from RTU device to numerical representation.
		/// </summary>
		/// <param name="readValues">Bool values that are read from RTU device.</param>
		/// <returns>Signal value converted from array of bools to number.</returns>
		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}

		/// <summary>
		/// Converts numerical representation of discrete signal to array of bools that is needed for changing signal value.
		/// </summary>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="value">Numerical representation of discrete signal value.</param>
		/// <returns>Array of bools needed for changing discrete signal value.</returns>
		private bool[] ByteToBoolArray(DiscreteSignalType discreteSignalType, byte value)
		{
			if (discreteSignalType == DiscreteSignalType.OneBit)
			{
				return new bool[1] { value == 1 };
			}

			return new bool[2] { (value & 2) == 2, (value & 1) == 1 };
		}

		private RtuConnection GetRtuConnection(int rtuId)
		{
			return rtuConnections.SingleOrDefault(r => r.RtuId == rtuId);
		}
	}
}
