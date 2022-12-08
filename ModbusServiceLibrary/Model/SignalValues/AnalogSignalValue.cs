using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public class AnalogSignalValue
	{
		/// <summary>
		/// Analog signal
		/// </summary>
		public AnalogSignal AnalogSignal { get; set; }
		
		/// <summary>
		/// Value of the analog signal
		/// </summary>
		public int Value { get; set; }
	}
}