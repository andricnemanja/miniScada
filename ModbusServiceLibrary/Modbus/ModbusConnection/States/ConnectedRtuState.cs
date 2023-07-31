using System;

namespace ModbusServiceLibrary.ModbusConnection.States
{
	/// <summary>
	/// Class <c>ConnectedRtuState</c> represents connected TCP state.
	/// </summary>
	public sealed class ConnectedRtuState : IRtuConnectionState
	{
		private readonly RtuConnection _rtuConnection;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectedRtuState"./>
		/// </summary>
		/// <param name="rtuConnection">Instance of the <see cref="RtuConnection"/> class.</param>
		public ConnectedRtuState(RtuConnection rtuConnection)
		{
			Console.WriteLine("Connected");
			_rtuConnection = rtuConnection;
		}

		/// <summary>
		/// Make TCP connection with RTU.
		/// </summary>
		/// <param name="ipAddress">IP Address of the RTU.</param>
		/// <param name="port">RTU port.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Connect(string ipAddress, int port)
		{
			return RtuConnectionResponse.Connected;
		}

		/// <summary>
		/// Disconnect from the RTU.
		/// </summary>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Disconnect()
		{
			_rtuConnection.ModbusMaster.Dispose();
			_rtuConnection.ConnectionState = new DisconnectedRtuState(_rtuConnection);
			return RtuConnectionResponse.Disconnected;
		}

		/// <summary>
		/// Execute write command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be changed.</param>
		/// <param name="writeValue">New signal value.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue)
		{
			command(1, signalAddress, writeValue);
			return RtuConnectionResponse.CommandExecuted;
		}

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
			readValue = command(1, signalAddress, numberOfPoints);
			return RtuConnectionResponse.CommandExecuted;
		}
	}
}
