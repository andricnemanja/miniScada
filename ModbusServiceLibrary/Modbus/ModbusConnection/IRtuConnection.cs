using System;
using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using NModbus;

namespace ModbusServiceLibrary.Modbus.ModbusConnection
{
	public interface IRtuConnection
	{
		IRtuConnectionState ConnectionState { get; set; }
		IRtuConnectionStateFactory ConnectionStateFactory { get; set; }
		IDynamicCacheManagerService DynamicCacheManagerServiceClient { get; set; }
		string IpAddress { get; set; }
		IModbusMaster ModbusMaster { get; set; }
		int Port { get; set; }
		int RtuId { get; set; }

		RtuConnectionResponse Connect(string ipAddress, int port);
		RtuConnectionResponse Disconnect();
		RtuConnectionResponse ExecuteReadCommand<T>(Func<byte, ushort, ushort, T> command, ushort signalAddress, ushort numberOfPoints, out T readValue);
		RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue);
	}
}