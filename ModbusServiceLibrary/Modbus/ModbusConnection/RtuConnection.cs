using System;
using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using NModbus;

namespace ModbusServiceLibrary.Modbus.ModbusConnection
{
	/// <summary>
	/// Class <c>RtuConnection</c> represents the TCP connection to RTU device.
	/// </summary>
	public sealed class RtuConnection : IRtuConnection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RtuConnection"./>
		/// </summary>
		/// <param name="rtuId">ID of RTU for which connection is created.</param>
		/// <param name="dynamicCacheManagerServiceClient">Instance of the <see cref="IDynamicCacheManagerService"/> class.</param>
		public RtuConnection(int rtuId, IDynamicCacheManagerService dynamicCacheManagerServiceClient, IRtuConnectionStateFactory rtuConnectionStateFactory)
		{
			RtuId = rtuId;
			DynamicCacheManagerServiceClient = dynamicCacheManagerServiceClient;
			ConnectionStateFactory = rtuConnectionStateFactory;
			ConnectionState = ConnectionStateFactory.CreateConnection(RtuConnectionState.Disconnected, this);
		}
		/// <summary>
		/// IP Address of RTU device.
		/// </summary>
		public string IpAddress { get; set; }
		/// <summary>
		/// Port number of RTU device.
		/// </summary>
		public int Port { get; set; }
		/// <summary>
		/// ID of the RTU.
		/// </summary>
		public int RtuId { get; set; }
		/// <summary>
		/// .
		/// </summary>
		public IModbusMaster ModbusMaster { get; set; }
		/// <summary>
		/// Current state of the RTU TCP connection.
		/// </summary>
		public IRtuConnectionState ConnectionState { get; set; }
		/// <summary>
		/// DynamicCacheManager service client.
		/// </summary>
		public IDynamicCacheManagerService DynamicCacheManagerServiceClient { get; set; }
		/// <summary>
		/// Factory for creating RTU connection states.
		/// </summary>
		public IRtuConnectionStateFactory ConnectionStateFactory { get; set; }

		/// <summary>
		/// Make TCP connection with RTU.
		/// </summary>
		/// <param name="ipAddress">IP Address of the RTU.</param>
		/// <param name="port">RTU port.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Connect(string ipAddress, int port) => ConnectionState.Connect(ipAddress, port);

		/// <summary>
		/// Disconnect from the RTU.
		/// </summary>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse Disconnect() => ConnectionState.Disconnect();

		/// <summary>
		/// Execute write command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be changed.</param>
		/// <param name="writeValue">New signal value.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue) => ConnectionState.ExecuteWriteCommand(command, signalAddress, writeValue);

		/// <summary>
		/// Execute read command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be read.</param>
		/// <param name="numberOfPoints">Number of points occupied by the signal.</param>
		/// <param name="readValue">Value that is read from the signal.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		public RtuConnectionResponse ExecuteReadCommand<T>(Func<byte, ushort, ushort, T> command, ushort signalAddress, ushort numberOfPoints, out T readValue) => ConnectionState.ExecuteReadCommand(command, signalAddress, numberOfPoints, out readValue);
	}
}
