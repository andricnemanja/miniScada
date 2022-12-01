using ModbusServiceLibrary.Model.Signals;
using System.ComponentModel;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public class DiscreteSignalValue
	{
		public DiscreteSignal DiscreteSignal { get; set; }
		public bool Value { get; set; }
	}
}