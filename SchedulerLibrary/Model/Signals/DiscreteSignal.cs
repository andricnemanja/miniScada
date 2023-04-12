namespace SchedulerLibrary.Model.Signals
{
	public class DiscreteSignal : ISignal
	{
		/// <summary>
		/// Unique identification number for analog signal.
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Name of the analog signal.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		public SignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignal"/> class.
		/// </summary>
		/// <param name="id">Number unique to the RTU.</param>
		/// <param name="name">Name of the signal.</param>
		public DiscreteSignal(int id, string name)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignal"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public DiscreteSignal(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			ID = discreteSignalStaticData.ID;
			Name = discreteSignalStaticData.Name;
			AccessType = discreteSignalStaticData.SignalAccessType;
		}
	}
	}
