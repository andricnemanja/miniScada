
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusClient
	{
		void Disconnect();
		bool TryReadCoils(int startingAddress, DiscreteSignalType discreteSignalType, out byte signalValue);
		bool TryReadSingleHoldingRegister(int startingAddress, out int value);
		bool TryWriteCoils(int coilAddress, DiscreteSignalType discreteSignalType, byte valueToWrite);
		bool TryWriteSingleHoldingRegister(int startingAddress, int value);
	}
}