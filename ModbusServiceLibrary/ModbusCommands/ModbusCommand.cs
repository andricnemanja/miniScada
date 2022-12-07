using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public abstract class ModbusCommand
	{
		protected IModbusConnection modbusConnection;

		protected ModbusCommand(IModbusConnection modbusConnection)
		{
			this.modbusConnection = modbusConnection;
		}

		public abstract void Execute();
	}
}
