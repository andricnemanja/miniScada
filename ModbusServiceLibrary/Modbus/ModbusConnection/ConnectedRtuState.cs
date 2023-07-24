using System;

namespace ModbusServiceLibrary.ModbusConnection
{
	public sealed class ConnectedRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;

		public ConnectedRtuState(RtuConnection rtuConnection)
		{
			Console.WriteLine("Connected");
			_rtuConnection = rtuConnection;
		}

		public RtuConnectionResponse Connect(string ipAddress, int port)
		{
			return RtuConnectionResponse.Connected;
		}

		public RtuConnectionResponse Disconnect()
		{
			_rtuConnection.ModbusMaster.Dispose();
			_rtuConnection.ConnectionState = new DisconnectedRtuState(_rtuConnection);
			return RtuConnectionResponse.Disconnected;
		}

		public RtuConnectionResponse ReadCoils(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			try
			{
				signalValue = _rtuConnection.ModbusMaster.ReadCoils(1, (ushort)startingAddress, (ushort)numberOfCoils);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				signalValue = new bool[0];
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}

		public RtuConnectionResponse ReadHoldingRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			try
			{
				value = _rtuConnection.ModbusMaster.ReadHoldingRegisters(1, (ushort)startingAddress, (ushort)numberOfRegisters);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				value = new ushort[0];
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}

		public RtuConnectionResponse ReadInputRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			try
			{
				value = _rtuConnection.ModbusMaster.ReadInputRegisters(1, (ushort)startingAddress, (ushort)numberOfRegisters);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				value = new ushort[0];
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}

		public RtuConnectionResponse ReadInputs(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			try
			{
				signalValue = _rtuConnection.ModbusMaster.ReadInputs(1, (ushort)startingAddress, (ushort)numberOfCoils);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				signalValue = new bool[0];
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}

		public RtuConnectionResponse WriteCoils(int coilAddress, bool[] valueToWrite)
		{
			try
			{
				_rtuConnection.ModbusMaster.WriteMultipleCoils(1, (ushort)coilAddress, valueToWrite);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}

		public RtuConnectionResponse WriteSingleHoldingRegister(int startingAddress, int value)
		{
			try
			{
				_rtuConnection.ModbusMaster.WriteSingleRegister(1, (ushort)startingAddress, (ushort)value);
				return RtuConnectionResponse.CommandExecuted;
			}
			catch
			{
				Console.WriteLine("Command Failed");
				_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
				return RtuConnectionResponse.ConnectionFailure;
			}
		}
	}
}
