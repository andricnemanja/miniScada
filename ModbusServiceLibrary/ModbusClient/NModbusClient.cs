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
		public ushort[] ReadHoldingRegisters(int startingAddress, int numberOfRegisters)
		{
			return master.ReadHoldingRegisters(1, (ushort)startingAddress, (ushort)numberOfRegisters);
		}

		public ushort[] ReadAnalogInputs(int startingAddress, int numberOfRegisters)
		{
			return master.ReadInputRegisters(1, (ushort)startingAddress, (ushort)numberOfRegisters);
		}

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

		public bool[] ReadCoils(int startingAddress, int numberOfCoils)
		{
			return master.ReadCoils(1, (ushort)startingAddress, (ushort)numberOfCoils);
		}
		public bool[] ReadDiscreteInputs(int startingAddress, int numberOfCoils)
		{
			return master.ReadInputs(1, (ushort)startingAddress, (ushort)numberOfCoils);
		}
		public void WriteMultipleCoil(int coilAddress, bool[] data)
		{
			master.WriteMultipleCoils(1, (ushort)coilAddress, data);
		}
		public void Disconnect()
		{
			master.Dispose();
		}
	}
}
