using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.Model.RTU
{
	public class RTU
	{
		public RTUData RTUData { get; set; }
		public RTUConnection Connection { get; set; }
		public List<AnalogSignalValue> AnalogSignalValues { get; set; }
		public List<DiscreteSignalValue> DiscreteSignalValues { get; set; }

	}
}
