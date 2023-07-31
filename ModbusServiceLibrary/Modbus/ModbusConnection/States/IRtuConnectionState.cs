using System;

namespace ModbusServiceLibrary.ModbusConnection.States
{
	public interface IRtuConnectionState
	{
		/// <summary>
		/// Make TCP connection with RTU.
		/// </summary>
		/// <param name="ipAddress">IP Address of the RTU.</param>
		/// <param name="port">RTU port.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		RtuConnectionResponse Connect(string ipAddress, int port);

		/// <summary>
		/// Disconnect from the RTU.
		/// </summary>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		RtuConnectionResponse Disconnect();

		/// <summary>
		/// Execute write command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be changed.</param>
		/// <param name="writeValue">New signal value.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		RtuConnectionResponse ExecuteWriteCommand<T>(Action<byte, ushort, T> command, ushort signalAddress, T writeValue);

		/// <summary>
		/// Execute read command on the device.
		/// </summary>
		/// <param name="command">Read command that needs to be executed.</param>
		/// <param name="signalAddress">Modbus address of the signal that needs to be read.</param>
		/// <param name="numberOfPoints">Number of points occupied by the signal.</param>
		/// <param name="readValue">Value that is read from the signal.</param>
		/// <returns><see cref="RtuConnectionResponse"/></returns>
		RtuConnectionResponse ExecuteReadCommand<T>(Func<byte, ushort, ushort, T> command, ushort signalAddress, ushort numberOfPoints, out T readValue);
	}
}