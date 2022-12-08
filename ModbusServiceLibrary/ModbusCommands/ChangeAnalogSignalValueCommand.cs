using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public class ChangeAnalogSignalValueCommand : ModbusCommand
	{
		public int PreviousValue { get; set; }
		public int NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public ChangeAnalogSignalValueCommand(IModbusConnection modbusConnection, int newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			NewValue = newValue;
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}

		public override void Execute()
		{
			PreviousValue = ReadPreviousValue();
			modbusConnection.WriteAnalogSignalValue(Rtu.RTUData.ID, SignalAddress, NewValue);
		}

		private int ReadPreviousValue()
		{
			return Rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
