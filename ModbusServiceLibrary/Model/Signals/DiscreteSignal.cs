namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="DiscreteSignal"/> models discrete signal from the RTU.
	/// </summary>
	public class DiscreteSignal
	{
		/// <summary>
		/// Unique identification number for digital signal.
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Digital signal address.
		/// </summary>
		public int Address { get; set; }
		/// <summary>
		/// Name of the discrete signal.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Signal type, one bit or two bit signal.
		/// </summary>
		public DiscreteSignalType SignalType { get; set; }
		/// <summary>
		/// Discrete signal mapping ID.
		/// </summary>
		public int MappingId { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="id">Unique identification number for digital signal.</param>
		/// <param name="address">Address of the signal.</param>
		/// <param name="name">Name of the signal.</param>
		public DiscreteSignal(int id, int address, string name, int mappingId)
		{
			ID = id;
			Address = address;
			Name = name;
			MappingId = mappingId;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="discreteSignalStaticData">Discrete signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public DiscreteSignal(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			ID = discreteSignalStaticData.ID;
			Address = discreteSignalStaticData.Address;
			Name = discreteSignalStaticData.Name;
			SignalType = (DiscreteSignalType)discreteSignalStaticData.SignalType;
			MappingId = discreteSignalStaticData.MappingId;
		}
	}
}
