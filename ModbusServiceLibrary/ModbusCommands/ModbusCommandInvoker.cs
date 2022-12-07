using System.Collections.Generic;
using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public class ModbusCommandInvoker : IModbusCommandInvoker
	{
		public Stack<ModbusCommand> commands = new Stack<ModbusCommand>();
		public IModbusConnection modbusConnection;

		public ModbusCommandInvoker(IModbusConnection modbusConnection)
		{
			this.modbusConnection = modbusConnection;
		}

		public void WriteAnalogSignalValue(int rtuId, int signalAddress, int newValue)
		{
			ModbusCommand changeAnalogSignalCommand = new ChangeAnalogSignalValueCommand(modbusConnection, newValue, rtuId, signalAddress);
			changeAnalogSignalCommand.Execute();
			commands.Push(changeAnalogSignalCommand);
		}

		public void WriteDiscreteSignalValue(int rtuId, int signalAddress, bool newValue)
		{
			ModbusCommand changeAnalogSignalCommand = new ChangeDiscreteSignalValueCommand(modbusConnection, newValue, rtuId, signalAddress);
			changeAnalogSignalCommand.Execute();
			commands.Push(changeAnalogSignalCommand);
		}

		public int ReadAnalogSignalValue(int rtuId, int signalAddress)
		{
			ReadAnalogSignalValueCommand readAnalogSignalCommand = new ReadAnalogSignalValueCommand(modbusConnection, rtuId, signalAddress);
			readAnalogSignalCommand.Execute();
			commands.Push(readAnalogSignalCommand);

			return readAnalogSignalCommand.NewValue;
		}

		public bool ReadDiscreteSignalValue(int rtuId, int signalAddress)
		{
			ReadDiscreteSignalValueCommand readDiscreteSignalCommand = new ReadDiscreteSignalValueCommand(modbusConnection, rtuId, signalAddress);
			readDiscreteSignalCommand.Execute();
			commands.Push(readDiscreteSignalCommand);

			return readDiscreteSignalCommand.NewValue;
		}
	}
}
