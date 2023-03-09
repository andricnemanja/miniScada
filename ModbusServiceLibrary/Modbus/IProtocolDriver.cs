namespace ModbusServiceLibrary.Modbus
{
	public interface IProtocolDriver
	{
		double ReadAnalogSignal(int signalId);
		string ReadDiscreteSignal(int signalId);
		bool TryWriteAnalogSignal(int signalId, double newValue);
		bool TryWriteDiscreteSignal(int signalId, string newState);
		bool TryConnectToRtu(int rtuId, string rtuAddress, int port);
	}
}