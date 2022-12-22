using System.Collections.Generic;

namespace ModbusServiceLibrary.ModbusCommands
{
	public interface IModbusCommandInvoker
	{
		Queue<ModbusCommand> Commands { get; set; }

		bool TryReadAnalogSignalValue(int rtuId, int signalAddress, out int value);
		bool TryReadDiscreteSignalValue(int rtuId, int signalAddress, out bool value);
		bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int newValue);
		bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, bool newValue);
	}
}