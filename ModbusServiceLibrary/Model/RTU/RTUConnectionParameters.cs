namespace ModbusServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTUData</c> models static RTU data.
	/// </summary>
	public class RTUConnectionParameters
	{

		/// <summary>
		/// Ip address for RTU
		/// </summary>
		public string IpAddress { get; set; }
		/// <summary>
		/// Port at which RTU can be accessed
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RTUConnectionParameters"/> class.
		/// </summary>
		/// <param name="rtuData">An instance of the <see cref="ModelServiceReference.RTUData"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public RTUConnectionParameters(ModelServiceReference.RTUData rtuData)
		{
			IpAddress = rtuData.IpAddress;
			Port = rtuData.Port;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="RTUConnectionParameters"/> class without data.
		/// </summary>
		public RTUConnectionParameters() {}
	}
}