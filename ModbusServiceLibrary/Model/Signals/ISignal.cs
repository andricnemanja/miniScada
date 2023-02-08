namespace ModbusServiceLibrary.Model.Signals
{
	public interface ISignal
	{
		/// <summary>
		/// Unique identification number for analog signal
		/// </summary>
		int ID { get; set; }
		/// <summary>
		/// Analog signal address
		/// </summary>
		int Address { get; set; }
		/// <summary>
		/// Name of the analog signal
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// Analog signal mapping ID
		/// </summary>
		int MappingId { get; set; }
	}
}
