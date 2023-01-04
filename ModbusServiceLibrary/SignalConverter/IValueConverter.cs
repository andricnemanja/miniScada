namespace ModbusServiceLibrary.SignalConverter
{
	public interface IValueConverter
	{
		double ConvertAnalogSignalToRealValue(int rtuId, int analogSignalAddress, double value);
		int ConvertRealValueToAnalogSignal(int rtuId, int analogSignalAddress, double value);
		void Initialize();
	}
}