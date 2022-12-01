namespace ModbusServiceLibrary.ModbusCommunication
{
	public interface IModbusWriter
	{
		void WriteAnalogSignalValue(int rtuId, int signalAddress, int value);
		void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool value);
	}
}