namespace ModbusServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="SignalMapping"/> contains data required to represent signal physicly.
	/// </summary>
	public class SignalMapping
	{
		/// <summary>
		/// ID of the RTU.
		/// </summary>
		public int RtuId { get; set; }
		/// <summary>
		/// Unique ID of the analog signal.
		/// </summary>
		public int AnalogSignalAddress { get; set; }
		/// <summary>
		/// Minimum value that can be presented ogn the sensor.
		/// </summary>
		public int MinSensorValue { get; set; }
		/// <summary>
		/// Maximum value that can be presented ogn the sensor.
		/// </summary>
		public int MaxSensorValue { get; set; }
		/// <summary>
		/// Minimum value of the real physical signal.
		/// </summary>
		public int MinRealValue { get; set; }
		/// <summary>
		/// Maximum value of the real physical signal.
		/// </summary>
		public int MaxRealValue { get; set;}
		/// <summary>
		/// Unit of the signal.
		/// </summary>
		public string Unit { get; set; }
	}
}
