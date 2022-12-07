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
	public class ChangeDiscreteSignalValueCommand : ModbusCommand
	{
		public bool PreviousValue { get; set; }
		public bool NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public ChangeDiscreteSignalValueCommand(IModbusConnection modbusConnection, bool newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			NewValue = newValue;
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}

		public override void Execute()
		{
			PreviousValue = ReadPreviousValue();
			NewValue = modbusConnection.WriteDiscreteSignalValue(Rtu.RTUData.ID, SignalAddress, NewValue);
		}

		private bool ReadPreviousValue()
		{
			return Rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
