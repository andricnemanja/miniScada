namespace ModbusServiceLibrary.SignalConverter
{
	public interface ISignalMapper
	{
		string ConvertDiscreteSignalValueToState(int mappingId, byte signalValue);
		double ConvertAnalogSignalToRealValue(int rtuId, double signalValue);
	}
}