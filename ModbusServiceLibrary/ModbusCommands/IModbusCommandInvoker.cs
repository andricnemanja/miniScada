namespace ModbusServiceLibrary.ModbusCommands
{
	public interface IModbusCommandInvoker
	{
		int ReadAnalogSignalValue(int rtuId, int signalAddress);
		bool ReadDiscreteSignalValue(int rtuId, int signalAddress);
		void WriteAnalogSignalValue(int rtuId, int signalAddress, int newValue);
		void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool newValue);
	}
}