namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="ModbusAnalogSignal"/> models analog signal from the RTU.
	/// </summary>
	public class ModbusAnalogSignal : IModbusSignal
	{
		/// <summary>
		/// Unique identification number for analog signal
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Name of the analog signal
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		public ModbusSignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusAnalogSignal"/> class.
		/// </summary>
		/// <param name="id">Number unique to the RTU.</param>
		/// <param name="name">Name of the signal.</param>
		public ModbusAnalogSignal(int id, string name)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusAnalogSignal"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public ModbusAnalogSignal(ModelServiceReference.ModelAnalogSignal analogSignalStaticData)
		{
			ID = analogSignalStaticData.ID;
			Name = analogSignalStaticData.Name;
			AccessType = (ModbusSignalAccessType)analogSignalStaticData.AccessType;
		}
	}
}
