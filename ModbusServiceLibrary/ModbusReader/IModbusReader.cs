namespace ModbusServiceLibrary.ModbusReader
{
	public interface IModbusReader
	{
		int ReadAnalogInput(int id, int signalAddress);
		bool ReadCoil(int id, int signalAddress);
		bool ReadDiscreteInput(int id, int signalAddress);
		int ReadRegister(int id, int signalAddress);
	}
}