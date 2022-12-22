using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Model
{
	/// <summary>
	/// Class <c>RTUConnection</c> models connection between client and RTU.
	/// </summary>
	public class RTUConnection
	{
		/// <summary>
		/// Connection status.
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// Class that interacts with Modbus Client.
		/// </summary>
		public IModbusClient Client { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RTUConnection"/> class.
		/// </summary>
		/// <param name="client">Instance of the <see cref="IModbusClient"/>.</param>
		/// <param name="status">Connection status.</param>
		public RTUConnection(IModbusClient client, bool status = false)
		{
			Status = status;
			Client = client;
		}
	}
}