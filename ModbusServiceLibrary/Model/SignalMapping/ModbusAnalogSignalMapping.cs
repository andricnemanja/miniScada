namespace ModbusServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="ModbusAnalogSignalMapping"/> contains data required to convert from analog signal value to real value.
	/// </summary>
	public class ModbusAnalogSignalMapping
	{
		/// <summary>
		/// ID of the RTU.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Mapping name
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Sensor value multiplicator.
		/// </summary>
		public double K { get; set; }
		/// <summary>
		/// Constant in y=kx+n.
		/// </summary>
		public double N { get; set; }
	}
}
