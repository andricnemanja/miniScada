using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus
{
	public interface IProtocolDriver
	{
		RtuConnectionResponse ReadAnalogSignal(int signalId, out double signalValue);
		RtuConnectionResponse ReadDiscreteSignal(int signalId, out string state);
		RtuConnectionResponse WriteAnalogSignal(int signalId, double newValue);
		RtuConnectionResponse WriteDiscreteSignal(int signalId, string newState);
		RtuConnectionResponse ConnectToRtu(int rtuId, string rtuAddress, int port);
		RtuConnectionResponse DisconnectFromRtu(int rtuId);
	}
}