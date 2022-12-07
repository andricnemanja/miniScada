using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public class DiscreteSignalValue
	{
		public DiscreteSignal DiscreteSignal { get; set; }
		public bool Value { get; set; }
	}
}