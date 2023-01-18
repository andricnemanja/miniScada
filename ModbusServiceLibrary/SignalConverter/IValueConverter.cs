namespace ModbusServiceLibrary.SignalConverter
{
	public interface IValueConverter
	{
		double ConvertAnalogSignalToRealValue(int rtuId, int analogSignalAddress, double value);
		int ConvertRealValueToAnalogSignal(int rtuId, int analogSignalAddress, double value);
		string ConvertDiscreteSignalToRealValue(int rtuId, int discreteSignalAddress, byte value);
		byte ConvertRealValueToDiscreteSignal(int rtuId, int discreteSignalAddress, string value);
		void Initialize();
	}
}