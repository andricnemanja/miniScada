using System.Collections.Generic;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTU</c> models a RTU.
	/// </summary>
	public class RTU
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
		/// Parameters for connecting to the RTU device.
		/// </summary>
		public RTUConnectionParameters RTUConnectionParameters { get; set; }

		/// <summary>
		/// List of signals.
		/// </summary>
		public List<ISignal> Signals { get; set; } = new List<ISignal>();


		/// <summary>
		/// Initializes a new instance of the <see cref="RTU"/> class.
		/// </summary>
		/// <param name="rtuStaticData">An instance of the <see cref="ModelServiceReference.RTU rtuStaticData"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public RTU(ModelServiceReference.RTU rtuStaticData)
		{
			Name = rtuStaticData.RTUData.Name;
			ID = rtuStaticData.RTUData.ID;
			RTUConnectionParameters = new RTUConnectionParameters(rtuStaticData.RTUData);
			foreach (var analogSignalStaticData in rtuStaticData.AnalogSignals)
			{
				Signals.Add(new AnalogSignal(analogSignalStaticData));
			}
			foreach (var discreteSignalStaticData in rtuStaticData.DiscreteSignals)
			{
				Signals.Add(new DiscreteSignal(discreteSignalStaticData));
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="RTU"/> class without data.
		/// </summary>
		public RTU() {}
	}
}
