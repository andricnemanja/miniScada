using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NModbus;
using Polly;
using Polly.Retry;

namespace ModbusServiceLibrary.ModbusConnection
{
	public sealed class ConnectingRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;
		private CancellationToken cancellationToken;
		private readonly RetryPolicy retryPolicy = Policy
			.Handle<System.Net.Sockets.SocketException>()
			.WaitAndRetryForever(retryAttemp => TimeSpan.FromSeconds(5));

		public ConnectingRtuState(RtuConnection rtuConnection)
		{
			Console.WriteLine("Connecting");
			_rtuConnection = rtuConnection;

			Task.Run(() =>
			{
				retryPolicy.Execute(() =>
				{
					TcpClient client = new TcpClient(_rtuConnection.IpAddress, _rtuConnection.Port);
					ModbusFactory modbusFactory = new ModbusFactory();
					_rtuConnection.ModbusMaster = modbusFactory.CreateMaster(client);
				});

				_rtuConnection.ConnectionState = new ConnectedRtuState(_rtuConnection);
			}, cancellationToken);
		}

		public RtuConnectionResponse Connect(string ipAddress, int port) => RtuConnectionResponse.Connecting;

		// TODO: Add cancelation token
		public RtuConnectionResponse Disconnect() => RtuConnectionResponse.Connecting;

		public RtuConnectionResponse ReadCoils(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			signalValue= new bool[0];
			return RtuConnectionResponse.Connecting;
		}

		public RtuConnectionResponse ReadInputs(int startingAddress, int numberOfCoils, out bool[] signalValue)
		{
			signalValue = new bool[0];
			return RtuConnectionResponse.Connecting;
		}

		public RtuConnectionResponse ReadHoldingRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			value = new ushort[0];
			return RtuConnectionResponse.Connecting;
		}

		public RtuConnectionResponse ReadInputRegisters(int startingAddress, int numberOfRegisters, out ushort[] value)
		{
			value = new ushort[0];
			return RtuConnectionResponse.Connecting;
		}

		public RtuConnectionResponse WriteSingleHoldingRegister(int startingAddress, int value) => RtuConnectionResponse.Connecting;

		public RtuConnectionResponse WriteCoils(int coilAddress, bool[] valueToWrite)
		=> RtuConnectionResponse.Connecting;
	}
}
