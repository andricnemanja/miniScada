using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model.Signals
{
	public class AnalogSignal : ISignal
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
		public SignalAccessType AccessType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignal"/> class.
		/// </summary>
		/// <param name="id">Number unique to the RTU.</param>
		/// <param name="name">Name of the signal.</param>
		public AnalogSignal(int id, string name)
		{
			ID = id;
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignal"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data. Data from the <see cref="ModelServiceReference"/> namespace.</param>
		public AnalogSignal(ModelServiceReference.AnalogSignal analogSignalStaticData)
		{
			ID = analogSignalStaticData.ID;
			Name = analogSignalStaticData.Name;
			AccessType = analogSignalStaticData.SignalAccessType;
		}
	}
}
