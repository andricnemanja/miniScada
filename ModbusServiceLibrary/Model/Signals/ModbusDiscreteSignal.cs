namespace ModbusServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class <see cref="ModbusDiscreteSignal"/> models discrete signal from the RTU.
	/// </summary>
	public class ModbusDiscreteSignal : IModbusSignal
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
		public ModbusSignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusDiscreteSignal"/> class.
		/// </summary>
		/// <param name="id">Unique identification number for digital signal.</param>
		/// <param name="name">Name of the signal.</param>
		public ModbusDiscreteSignal(int id, string name)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusDiscreteSignal"/> class.
		/// </summary>
		/// <param name="discreteSignalStaticData">Discrete signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public ModbusDiscreteSignal(ModelServiceReference.ModelDiscreteSignal discreteSignalStaticData)
		{
			ID = discreteSignalStaticData.ID;
			Name = discreteSignalStaticData.Name;
			AccessType = (ModbusSignalAccessType)discreteSignalStaticData.AccessType;
		}
	}
}
