using System.Net.Sockets;
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
		/// Read single coil from the RTU.
		/// </summary>
		/// <param name="startingAddress">Address of the RTU.</param>
		/// <param name="value">Value that has been read.</param>
		/// <returns>Confirmation that method was executed successfully.</returns>
		public bool TryReadSingleCoil(int startingAddress, out bool value)
		{
			try
			{
				value = master.ReadCoils(1, (ushort)startingAddress, 1)[0];
				return true;
			}
			catch
			{
				value = false;
				return false;
			}
		}

		/// <summary>
		/// Write in value for the single coil.
		/// </summary>
		/// <param name="coilAddress">Address of the coil.</param>
		/// <param name="value">Value that needs to be written.</param>
		/// <returns>Confirmation that method was executed successfully.</returns>
		public bool TryWriteSingleCoil(int coilAddress, bool value)
		{
			try
			{
				master.WriteSingleCoil(1, (ushort)coilAddress, value);
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
		public bool TryReadCoils(int startingAddress, int numberOfCoils, out bool[] values)
		{
			values = null;
			try
			{
				values = master.ReadCoils(1, (ushort)startingAddress, (ushort)numberOfCoils);
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
		public bool TryWriteMultipleCoil(int coilAddress, bool[] data)
		{
			try
			{
				master.WriteMultipleCoils(1, (ushort)coilAddress, data);
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
	}
}
