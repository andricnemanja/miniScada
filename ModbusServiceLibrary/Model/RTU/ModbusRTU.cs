using System.Collections.Generic;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTU</c> models a RTU.
	/// </summary>
	public class ModbusRTU
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
		public List<IModbusSignal> Signals { get; set; } = new List<IModbusSignal>();


		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusRTU"/> class.
		/// </summary>
		/// <param name="rtuStaticData">An instance of the <see cref="ModelServiceReference.RTU rtuStaticData"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public ModbusRTU(ModelServiceReference.RTU rtuStaticData)
		{
			Name = rtuStaticData.RTUData.Name;
			ID = rtuStaticData.RTUData.ID;
			RTUConnectionParameters = new RTUConnectionParameters(rtuStaticData.RTUData);
			foreach (var analogSignalStaticData in rtuStaticData.AnalogSignals)
			{
				Signals.Add(new ModbusAnalogSignal(analogSignalStaticData));
			}
			foreach (var discreteSignalStaticData in rtuStaticData.DiscreteSignals)
			{
				Signals.Add(new ModbusDiscreteSignal(discreteSignalStaticData));
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusRTU"/> class without data.
		/// </summary>
		public ModbusRTU() {}
	}
}
