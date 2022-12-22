using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public abstract class ModbusCommand
	{
		/// <summary>
		/// Class that interacts with the modbus device
		/// </summary>
		protected IModbusConnection modbusConnection;

		/// <summary>
		/// Initializes a new instance of the <see cref="RtuRepository"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		protected ModbusCommand(IModbusConnection modbusConnection)
		{
			this.modbusConnection = modbusConnection;
		}
		/// <summary>
		/// Initialize static data by reading all of RTUs
		/// </summary>
		public abstract bool Execute();
	}
}
