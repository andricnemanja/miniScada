using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTU</c> models a RTU.
	/// </summary>
	public class RTU
	{
		/// <summary>
		/// Static data of the RTU.
		/// </summary>
		public RTUData RTUData { get; set; }

		/// <summary>
		/// Attribut containing connection.
		/// </summary>
		public RTUConnection Connection { get; set; }

		/// <summary>
		/// List of analog signal values.
		/// </summary>
		public List<AnalogSignalValue> AnalogSignalValues { get; set; } = new List<AnalogSignalValue>();

		/// <summary>
		/// List of discrete signal values.
		/// </summary>
		public List<DiscreteSignalValue> DiscreteSignalValues { get; set; } = new List<DiscreteSignalValue>();

		/// <summary>
		/// Initializes a new instance of the <see cref="RTU"/> class.
		/// </summary>
		/// <param name="rtuStaticData">Static data of the RTU.</param>
		public RTU(ModelServiceReference.RTU rtuStaticData)
		{
			RTUData = new RTUData(rtuStaticData.RTUData);
			foreach (var analogSignalStaticData in rtuStaticData.AnalogSignals)
			{
				AnalogSignalValues.Add(new AnalogSignalValue(analogSignalStaticData));
			}
			foreach (var discreteSignalStaticData in rtuStaticData.DiscreteSignals)
			{
				DiscreteSignalValues.Add(new DiscreteSignalValue(discreteSignalStaticData));
			}

			Connection = new RTUConnection(null, false);

		}

	}
}
