using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Base class of other command classes.
	/// </summary>
	public abstract class ModbusCommand
	{
		/// <summary>
		/// Class that interacts with the modbus device.
		/// </summary>
		protected IModbusSimulatorClient modbusSimulatorClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusCommand"/>.
		/// </summary>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class.</param>
		protected ModbusCommand(IModbusSimulatorClient modbusConnection)
		{
			this.modbusSimulatorClient = modbusConnection;
		}
		/// <summary>
		/// Initialize static data by reading all of RTUs.
		/// </summary>
		public abstract bool Execute();
	}
}
