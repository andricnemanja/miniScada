using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ModbusServiceLibrary.CommandResult;
using NModbus;
using Polly;
using Polly.Retry;

namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	/// <summary>
	/// Class <c>ConnectingRtuState</c> represents connecting TCP state.
	/// </summary>
	public sealed class ConnectingRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;
		private CancellationToken cancellationToken;
		private readonly RetryPolicy retryPolicy = Policy
			.Handle<System.Net.Sockets.SocketException>()
			.WaitAndRetryForever(retryAttemp => TimeSpan.FromSeconds(5));

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectingRtuState"/> and starts connecting to the RTU.
		/// </summary>
		/// <param name="rtuConnection">Instance of the <see cref="RtuConnection"/> class.</param>
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

				_rtuConnection.DynamicCacheManagerServiceClient.ProcessCommandResult(new ConnectToRtuResult(_rtuConnection.RtuId));
				_rtuConnection.ConnectionState = _rtuConnection.ConnectionStateFactory.CreateConnection(RtuConnectionState.Online, _rtuConnection);
			}, cancellationToken);
		}

		/// <summary>
		/// Make TCP connection with RTU.
		/// </summary>
		/// <param name="ipAddress">IP Address of the RTU.</param>
		/// <param name="port">RTU port.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Connect(string ipAddress, int port) => RtuConnectionResponse.Connecting;

		// TODO: Add cancelation token
		/// <summary>
		/// Disconnect from the RTU.
		/// </summary>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Disconnect() => RtuConnectionResponse.Connecting;

		/// <summary>
		/// Execute write command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be changed.</param>
		/// <param name="writeValue">New signal value.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue) => RtuConnectionResponse.Connecting;

		/// <summary>
		/// Execute read command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be read.</param>
		/// <param name="numberOfPoints">Number of points occupied by the signal.</param>
		/// <param name="readValue">Value that is read from the signal.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteReadCommand<T>(Func<byte, ushort, ushort, T> command, ushort signalAddress, ushort numberOfPoints, out T readValue)
		{
			readValue = default;
			return RtuConnectionResponse.Connecting;
		}
	}
}
