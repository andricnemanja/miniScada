using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.ModbusClient
{
	public interface IModbusClient2
	{
		//void Disconnect();
		bool TryReadCoils(int rtuId, int startingAddress, int numberOfCoils, out bool[] signalValue);
		bool TryConnect(int rtuId, string rtuAddress, int rtuPort);
		//bool TryReadSingleHoldingRegister(int startingAddress, out int value);
		bool TryWriteCoils(int rtuId, int coilAddress,  bool[] valueToWrite);
		//bool TryWriteSingleHoldingRegister(int startingAddress, int value);
	}
}