using ModbusServiceLibrary.ModbusConnection;

namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusConnectionManager
	{
		/// <summary>
		/// Get connection for RTU.
		/// </summary>
		/// <param name="rtuId">ID of the RTU for which connection is requested.</param>
		RtuConnection GetRtuConnection(int rtuId);
	}
}