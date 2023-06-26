namespace SchedulerService.Model.Signals
{
	public class SchedulerDiscreteSignal : ISchedulerSignal
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
		public SchedulerSignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SchedulerDiscreteSignal"/> class.
		/// </summary>
		/// <param name="id">Number unique to the RTU.</param>
		/// <param name="name">Name of the signal.</param>
		public SchedulerDiscreteSignal(int id, string name)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SchedulerAnalogSignal"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public SchedulerDiscreteSignal(ModelServiceReference.ModelDiscreteSignal discreteSignalStaticData)
		{
			ID = discreteSignalStaticData.ID;
			Name = discreteSignalStaticData.Name;
			AccessType = (SchedulerSignalAccessType)discreteSignalStaticData.AccessType;
		}
	}
	}
