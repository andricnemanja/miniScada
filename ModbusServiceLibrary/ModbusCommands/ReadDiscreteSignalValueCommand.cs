using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusCommands
{
	public class ReadDiscreteSignalValueCommand : ModbusCommand
	{
		public bool PreviousValue { get; set; }
		public bool NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public ReadDiscreteSignalValueCommand(IModbusConnection modbusConnection, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}

		public override void Execute()
		{
			NewValue = modbusConnection.ReadCoil(Rtu.RTUData.ID, SignalAddress);
		}
	}
}
