using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.Model.RTU
{
	public class RTU
	{
		/// <summary>
		/// Static data of the RTU
		/// </summary>
		public RTUData RTUData { get; set; }

		public RTUConnection Connection { get; set; }

		/// <summary>
		/// List of analog signal values
		/// </summary>
		public List<AnalogSignalValue> AnalogSignalValues { get; set; }

		/// <summary>
		/// List of discrete signal values
		/// </summary>
		public List<DiscreteSignalValue> DiscreteSignalValues { get; set; }


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

		}

	}
}
