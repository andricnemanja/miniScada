using System.Net.Sockets;
using ModbusServiceLibrary.Model.Signals;
using NModbus;

namespace ModbusServiceLibrary.ModbusClient
{
	/// <summary>
	/// Class <c>NModbusClient</c> models a Modbus client.
	/// Contains methods for commmunicating and operating with RTU.
	/// </summary>
	public sealed class NModbusClient : IModbusClient
	{
		private readonly IModbusMaster master;

		public NModbusClient(string ipAddress, int port)
		{
			TcpClient client = new TcpClient(ipAddress, port);
			var factory = new ModbusFactory();
			master = factory.CreateMaster(client);
		}


		/// <summary>
		/// Read single holding register from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Value that we read.</param>
		/// <returns>Confirmation that method was executed successfully.</returns>
		public bool TryReadSingleHoldingRegister(int startingAddress, out int value)
		{
			try
			{
				ushort[] valueArr = master.ReadHoldingRegisters(1, (ushort)startingAddress, 1);
				value = valueArr[0];
				return true;
			}
			catch
			{
				value = 0;
				return false;
			}
		}

		/// <summary>
		/// Write in the value of the single holding register.
		/// </summary>
		/// <param name="startingAddress">Address of the signal.</param>
		/// <param name="value">Value that needs to be written.</param>
		/// <returns>Confirmation that method was executed successfully.</returns>
		public bool TryWriteSingleHoldingRegister(int startingAddress, int value)
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

		}

		/// <summary>
		/// Read values of multiple coils.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="numberOfCoils">Number of coil that we read from.</param>
		/// <returns>Array of values that were read.</returns>
		public bool TryReadCoils(int startingAddress, DiscreteSignalType discreteSignalType, out byte signalValue)
		{
			signalValue = 0;
			try
			{
				if (discreteSignalType == DiscreteSignalType.TwoBit)
					signalValue = BoolArrayToByte(master.ReadCoils(1, (ushort)startingAddress, 2));
				else
					signalValue = BoolArrayToByte(master.ReadCoils(1, (ushort)startingAddress, 1));
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Write in values for multiple coils.
		/// </summary>
		/// <param name="coilAddress">Address of the RTU.</param>
		/// <param name="data">Values that need to be written.</param>
		public bool TryWriteCoils(int coilAddress, DiscreteSignalType discreteSignalType, byte valueToWrite)
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
		}

		/// <summary>
		/// Disconnect. 
		/// </summary>
		public void Disconnect()
		{
			master.Dispose();
		}

		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}

		private bool[] ByteToBoolArray(DiscreteSignalType discreteSignalType, byte value)
		{
			if (discreteSignalType == DiscreteSignalType.OneBit)
			{
				return value == 1 ? new bool[1] { true } : new bool[1] { false };
			}

			switch (value)
			{
				case 0: return new bool[2] { false, false };
				case 1: return new bool[2] { false, true };
				case 2: return new bool[2] { true, false };
				default: return new bool[2] { true, true };
			}
		}
	}
}
