namespace ModbusServiceLibrary.SignalConverter
{
	public interface IValueConverter
	{
		double ConvertAnalogSignalToRealValue(int rtuId, int analogSignalAddress, double value);
		int ConvertRealValueToAnalogSignal(int rtuId, int analogSignalAddress, double value);
		bool ConvertDiscreteSignalToRealValue(int rtuId, int discreteSignalAddress, bool value);
		bool ConvertRealValueToDiscreteSignal(int rtuId, int discreteSignalAddress, bool value);
		void Initialize();
	}
}