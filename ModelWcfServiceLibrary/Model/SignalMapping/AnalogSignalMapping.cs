namespace ModelWcfServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="AnalogSignalMapping"/> contains data required to represent signal physicly.
	/// </summary>
	public class AnalogSignalMapping
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
		public int K { get; set; }
		/// <summary>
		/// Constant in y=kx+n.
		/// </summary>
		public int N { get; set; }
	}
}
