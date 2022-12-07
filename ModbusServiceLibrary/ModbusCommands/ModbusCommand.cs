using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModbusCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
