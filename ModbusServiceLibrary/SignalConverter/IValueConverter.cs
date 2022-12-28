namespace ModbusServiceLibrary.SignalConverter
{
	public interface IValueConverter
	{
		int ConvertToRealValue(int rtuId, int analogSignalAddress, int value);
		int ConvertToSensorValue(int rtuId, int analogSignalAddress, int value);
		string GetSignalUnit(int rtuId, int analogSignalAddress);
	}
}