namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="DiscreteSignal"/> models discrete signal from the RTU.
	/// </summary>
	public class DiscreteSignal : ISignal
	{
		/// <summary>
		/// Unique identification number for digital signal.
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Name of the discrete signal.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		public SignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="id">Unique identification number for digital signal.</param>
		/// <param name="address">Address of the signal.</param>
		/// <param name="name">Name of the signal.</param>
		public DiscreteSignal(int id, int address, string name, int mappingId)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="discreteSignalStaticData">Discrete signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public DiscreteSignal(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			ID = discreteSignalStaticData.ID;
			Name = discreteSignalStaticData.Name;
			AccessType = (SignalAccessType)discreteSignalStaticData.AccessType;
		}
	}
}
