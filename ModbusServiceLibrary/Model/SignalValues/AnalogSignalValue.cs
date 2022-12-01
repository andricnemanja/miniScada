using ModbusServiceLibrary.Model.Signals;
using System.ComponentModel;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public class AnalogSignalValue
	{
		public AnalogSignal AnalogSignal { get; set; }
		public int Value { get; set; }
	}
}