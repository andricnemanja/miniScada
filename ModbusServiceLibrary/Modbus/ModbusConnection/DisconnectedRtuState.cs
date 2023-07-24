using System;

namespace ModbusServiceLibrary.ModbusConnection
{
	public sealed class DisconnectedRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;

		public DisconnectedRtuState(RtuConnection rtuConnection)
		{
			Console.WriteLine("Disconnected");
			_rtuConnection = rtuConnection;
		}

		public RtuConnectionResponse Connect(string ipAddress, int port)
		{
			_rtuConnection.IpAddress = ipAddress;
			_rtuConnection.Port = port;
			_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
			return RtuConnectionResponse.CommandExecuted;
		}

		public RtuConnectionResponse Disconnect() => RtuConnectionResponse.Disconnected;

		public RtuConnectionResponse ReadCoils(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			signalValue = new bool[0];
			return RtuConnectionResponse.Disconnected;
		}

		public RtuConnectionResponse ReadInputs(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			signalValue = new bool[0];
			return RtuConnectionResponse.Disconnected;
		}

		public RtuConnectionResponse ReadHoldingRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			value = new ushort[0];
			return RtuConnectionResponse.Disconnected;
		}

		public RtuConnectionResponse ReadInputRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			value = new ushort[0];
			return RtuConnectionResponse.Disconnected;
		}

		public RtuConnectionResponse WriteSingleHoldingRegister(int startingAddress, int value) => RtuConnectionResponse.Disconnected;

		public RtuConnectionResponse WriteCoils(int coilAddress, bool[] valueToWrite)
		=> RtuConnectionResponse.Disconnected;
	}
}
