namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="DiscreteSignal"/> models discrete signal from the RTU.
	/// </summary>
	public class DiscreteSignal
	{
		/// <summary>
		/// Unique identification number for digital signal
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Digital signal address
		/// </summary>
		public int Address { get; set; }
		/// <summary>
		/// Name of the discrete signal
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="iD">Number unique to the RTU.</param>
		/// <param name="address">Address of the signal.</param>
		/// <param name="name">Name of the signal.</param>
		public DiscreteSignal(int iD, int address, string name)
		{
			ID = iD;
			Address = address;
			Name = name;
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
		}
	}
}
