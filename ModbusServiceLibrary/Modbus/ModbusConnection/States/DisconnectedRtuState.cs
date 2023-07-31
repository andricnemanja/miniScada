using System;
using ModbusServiceLibrary.Modbus.ModbusMaster;

namespace ModbusServiceLibrary.ModbusConnection.States
{
	public sealed class DisconnectedRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectedRtuState"./>
		/// </summary>
		/// <param name="rtuConnection">Instance of the <see cref="RtuConnection"/> class.</param>
		public DisconnectedRtuState(RtuConnection rtuConnection)
		{
			Console.WriteLine("Disconnected");
			_rtuConnection = rtuConnection;
			_rtuConnection.ModbusMaster = new NullModbusMaster();
		}

		/// <summary>
		/// Make TCP connection with RTU.
		/// </summary>
		/// <param name="ipAddress">IP Address of the RTU.</param>
		/// <param name="port">RTU port.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Connect(string ipAddress, int port)
		{
			_rtuConnection.IpAddress = ipAddress;
			_rtuConnection.Port = port;
			_rtuConnection.ConnectionState = new ConnectingRtuState(_rtuConnection);
			return RtuConnectionResponse.CommandExecuted;
		}

		/// <summary>
		/// Disconnect from the RTU.
		/// </summary>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Disconnect() => RtuConnectionResponse.Disconnected;

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
			return RtuConnectionResponse.Disconnected;
		}

		/// <summary>
		/// Execute write command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be changed.</param>
		/// <param name="writeValue">New signal value.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue) => RtuConnectionResponse.Disconnected;
	}
}
