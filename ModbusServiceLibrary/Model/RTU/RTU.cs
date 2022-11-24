using ModbusServiceLibrary.Model.SignalValues;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
