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

	}
}
