namespace ModbusServiceLibrary.Model.Signals
{
	public interface ISignal
	{
		/// <summary>
		/// Unique identification number for analog signal
		/// </summary>
		int ID { get; set; }
		/// <summary>
		/// Name of the analog signal
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		SignalAccessType AccessType { get; set; }
	}
}
