namespace ModbusServiceLibrary.Modbus
{
	public interface IProtocolDriver
	{
		bool TryReadAnalogSignal(int signalId, out double signalValue);
		bool TryReadDiscreteSignal(int signalId, out string state);
		bool TryWriteAnalogSignal(int signalId, double newValue);
		bool TryWriteDiscreteSignal(int signalId, string newState);
		bool TryConnectToRtu(int rtuId, string rtuAddress, int port);

		void TryReadAnalogSignal(int signalId);
	}
}