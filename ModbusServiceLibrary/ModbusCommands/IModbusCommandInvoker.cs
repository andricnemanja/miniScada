using System.Collections.Generic;

namespace ModbusServiceLibrary.ModbusCommands
{
	public interface IModbusCommandInvoker
	{
		Queue<ModbusCommand> Commands { get; }

		bool TryReadAnalogSignalValue(int rtuId, int signalAddress, out int value);
		bool TryReadDiscreteSignalValue(int rtuId, int signalAddress, out byte value);
		bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int newValue);
		bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, byte newValue);
	}
}