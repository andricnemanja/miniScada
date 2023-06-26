using SchedulerService.Model.Signals;
using System.Collections.Generic;

namespace SchedulerService.Model.RTU
{
	/// <summary>
	/// Holds information crucial for the scheduler.
	/// </summary>
	public class SchedulerRTU
	{
		/// <summary>
		/// Name of the RTU
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Unique identification number for RTU
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// List of signals.
		/// </summary>
		public List<ISchedulerSignal> Signals { get; set; } = new List<ISchedulerSignal>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Model.RTU"/> class.
		/// </summary>
		/// <param name="rtuStaticData">An instance of the <see cref="ModelServiceReference.RTU rtuStaticData"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public SchedulerRTU(ModelServiceReference.ModelRTU rtuStaticData)
		{
			Name = rtuStaticData.RTUData.Name;
			ID = rtuStaticData.RTUData.ID;
			foreach (var analogSignalStaticData in rtuStaticData.AnalogSignals)
			{
				Signals.Add(new SchedulerAnalogSignal(analogSignalStaticData));
			}
			foreach (var discreteSignalStaticData in rtuStaticData.DiscreteSignals)
			{
				Signals.Add(new SchedulerDiscreteSignal(discreteSignalStaticData));
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Model.RTU"/> class without data.
		/// </summary>
		public SchedulerRTU() { }
	}
}
