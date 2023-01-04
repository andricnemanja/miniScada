namespace ModbusServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="DiscreteSignalMapping"/> contains data required to represent signal physicly.
	/// </summary>
	public class DiscreteSignalMapping
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
		/// 
		/// </summary>
		public bool Inverted { get; set; }

	}
}
