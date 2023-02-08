namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="AnalogSignal"/> models analog signal from the RTU.
	/// </summary>
	public class AnalogSignal : ISignal
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
		/// <summary>
		/// Analog signal mapping ID
		/// </summary>
		public int MappingId { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignal"/> class.
		/// </summary>
		/// <param name="id">Number unique to the RTU.</param>
		/// <param name="address">Address of the signal.</param>
		/// <param name="name">Name of the signal.</param>
		public AnalogSignal(int id, int address, string name, int mappingId)
		{
			ID = id;
			Address = address;
			Name = name;
			MappingId = mappingId;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignal"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public AnalogSignal(ModelServiceReference.AnalogSignal analogSignalStaticData)
		{
			ID = analogSignalStaticData.ID;
			Address = analogSignalStaticData.Address;
			Name = analogSignalStaticData.Name;
			MappingId = analogSignalStaticData.MappingId;
		}
	}
}
