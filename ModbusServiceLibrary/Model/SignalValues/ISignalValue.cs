using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public interface ISignalValue
	{
		ISignal SignalData { get; set; }
	}
}
