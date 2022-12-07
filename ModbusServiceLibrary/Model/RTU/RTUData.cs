namespace ModbusServiceLibrary.Model.RTU
{
	public class RTUData
	{
		/// <summary>
		/// Name of the RTU
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Unique identification number for RTU
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Ip address for RTU
		/// </summary>
		public string IpAddress { get; set; }
		/// <summary>
		/// Port at which RTU can be accessed
		/// </summary>
		public int Port { get; set; }
	}
}