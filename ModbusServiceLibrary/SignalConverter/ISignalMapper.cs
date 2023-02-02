namespace ModbusServiceLibrary.SignalConverter
{
	public interface ISignalMapper
	{
		string ConvertDiscreteSignalValueToState(int mappingId, byte signalValue);
	}
}