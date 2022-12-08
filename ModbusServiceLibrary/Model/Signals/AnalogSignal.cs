namespace ModbusServiceLibrary.Model.Signals
{
	public class AnalogSignal
	{
		/// <summary>
		/// Unique identification number for analog signal
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Analog signal address
		/// </summary>
		public int Address { get; set; }
		/// <summary>
		/// Name of the analog signal
		/// </summary>
		public string Name { get; set; }

		public AnalogSignal(int iD, int address, string name)
		{
			ID = iD;
			Address = address;
			Name = name;
		}

		public AnalogSignal()
		{

		}
	}
}
