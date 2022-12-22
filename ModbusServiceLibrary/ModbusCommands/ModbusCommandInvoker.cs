using System.Collections.Generic;
using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Class responsible for writing and reading signal, queuing and unqueuing them.
	/// </summary>
	public sealed class ModbusCommandInvoker : IModbusCommandInvoker
	{
		/// <summary>
		/// Class that interacts with the modbus device.
		/// </summary>
		private readonly IModbusConnection modbusConnection;
		readonly object lockObject = new object();

		/// <summary>
		/// An instance of the <see cref="ModbusCommandInvoker"/> class.
		/// </summary>
		/// <param name="modbusConnection">An instance of the <see cref="ModbusConnection"/> class.</param>
		public ModbusCommandInvoker(IModbusConnection modbusConnection)
		{
			this.modbusConnection = modbusConnection;
		}

		/// <summary>
		/// Queue of commands. Commands are executed sequentially.
		/// </summary>
		public Queue<ModbusCommand> Commands { get; set; } = new Queue<ModbusCommand>();
		/// <summary>
		/// Writes the new value of the analog signal.
		/// </summary>
		/// <param name="rtuId">Number specific and unique to the RTU.</param>
		/// <param name="signalAddress">Address of the specific signal.</param>
		/// <param name="newValue">New value that we are writing.</param>
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
		/// <summary>
		/// Writes the new value of the discrete signal.
		/// </summary>
		/// <param name="rtuId">Number specific and unique to the RTU.</param>
		/// <param name="signalAddress">Address of the specific signal.</param>
		/// <param name="newValue">New value that we are writing.</param>
		public bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, bool newValue)
		{
			ModbusCommand changeDiscreteSignalCommand = new ChangeDiscreteSignalValueCommand(modbusConnection, newValue, rtuId, signalAddress);
			lock (lockObject)
			{
				if (!changeAnalogSignalCommand.Execute())
					return false;
				Commands.Enqueue(changeAnalogSignalCommand);
			}
			return true;
		}
		/// <summary>
		/// Reads analog signal value from the RTU.
		/// </summary>
		/// <param name="rtuId">Number specific and unique to the RTU.</param>
		/// <param name="signalAddress">Address of the specific signal.</param>
		/// <returns>New value read from the RTU.</returns>
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
		/// <summary>
		/// Reads discrete signal value from the RTU.
		/// </summary>
		/// <param name="rtuId">Number specific and unique to the RTU.</param>
		/// <param name="signalAddress">Address of the specific signal.</param>
		/// <returns>New value read from the RTU.</returns>
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
