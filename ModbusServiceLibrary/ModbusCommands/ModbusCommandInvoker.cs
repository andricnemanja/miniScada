using System.Collections.Generic;
using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ModbusCommandInvoker : IModbusCommandInvoker
	{
		private readonly IModbusConnection modbusConnection;
		readonly object lockObject = new object();


		public ModbusCommandInvoker(IModbusConnection modbusConnection)
		{
			this.modbusConnection = modbusConnection;
		}

		public Queue<ModbusCommand> Commands { get; set; } = new Queue<ModbusCommand>();

		public bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int newValue)
		{
			ModbusCommand changeAnalogSignalCommand = new ChangeAnalogSignalValueCommand(modbusConnection, newValue, rtuId, signalAddress);
			lock (lockObject)
			{
				if (!changeAnalogSignalCommand.Execute())
					return false;
				Commands.Enqueue(changeAnalogSignalCommand);
			}
			return true;
		}

		public bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, bool newValue)
		{
			ModbusCommand changeAnalogSignalCommand = new ChangeDiscreteSignalValueCommand(modbusConnection, newValue, rtuId, signalAddress);
			lock (lockObject)
			{
				if (!changeAnalogSignalCommand.Execute())
					return false;
				Commands.Enqueue(changeAnalogSignalCommand);
			}
			return true;
		}

		public bool TryReadAnalogSignalValue(int rtuId, int signalAddress, out int value)
		{
			ReadAnalogSignalValueCommand readAnalogSignalCommand = new ReadAnalogSignalValueCommand(modbusConnection, rtuId, signalAddress);
			value = 0;
			lock (lockObject)
			{
				if (!readAnalogSignalCommand.Execute())
					return false;
				Commands.Enqueue(readAnalogSignalCommand);
			}
			value = readAnalogSignalCommand.NewValue;

			return true;
		}

		public bool TryReadDiscreteSignalValue(int rtuId, int signalAddress, out bool value)
		{
			ReadDiscreteSignalValueCommand readDiscreteSignalCommand = new ReadDiscreteSignalValueCommand(modbusConnection, rtuId, signalAddress);
			value = false;
			lock (lockObject)
			{
				if (!readDiscreteSignalCommand.Execute())
					return false;
				Commands.Enqueue(readDiscreteSignalCommand);
			}

			value = readDiscreteSignalCommand.NewValue;
			return true;
		}
	}
}
