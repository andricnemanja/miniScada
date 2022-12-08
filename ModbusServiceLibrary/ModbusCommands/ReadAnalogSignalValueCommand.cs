using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public class ReadAnalogSignalValueCommand : ModbusCommand
	{
		public int PreviousValue { get; set; }
		public int NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public ReadAnalogSignalValueCommand(IModbusConnection modbusConnection, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}

		public override void Execute()
		{
			PreviousValue = ReadPreviousValue();
			NewValue = modbusConnection.ReadRegister(Rtu.RTUData.ID, SignalAddress);
		}

		private int ReadPreviousValue()
		{
			return Rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
