namespace ModbusServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTUData</c> models data of the RTU.
	/// </summary>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="RTUData"/> class.
		/// </summary>
		/// <param name="rtuData">Static data of the RTU. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public RTUData(ModelServiceReference.RTUData rtuData)
		{
			Name = rtuData.Name;
			ID = rtuData.ID;
			IpAddress = rtuData.IpAddress;
			Port = rtuData.Port;
		}
	}
}