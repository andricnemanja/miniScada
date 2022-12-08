﻿using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ChangeDiscreteSignalValueCommand : ModbusCommand
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
			modbusConnection.WriteDiscreteSignalValue(Rtu.RTUData.ID, SignalAddress, NewValue);
		}

		private bool ReadPreviousValue()
		{
			return Rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
