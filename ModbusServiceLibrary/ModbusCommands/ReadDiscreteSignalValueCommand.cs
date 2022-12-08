using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ReadDiscreteSignalValueCommand : ModbusCommand
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
			PreviousValue = ReadPreviousValue();
			NewValue = modbusConnection.ReadCoil(Rtu.RTUData.ID, SignalAddress);
		}

		private bool ReadPreviousValue()
		{
			return Rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
