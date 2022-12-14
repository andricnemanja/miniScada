using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ChangeAnalogSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ChangeAnalogSignalValueCommand"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		/// <param name="newValue">Value that needs to be written</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned</param>
		public ChangeAnalogSignalValueCommand(IModbusConnection modbusConnection, int newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			NewValue = newValue;
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}

		public int PreviousValue { get; set; }
		public int NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public override void Execute()
		{
			PreviousValue = ReadPreviousValue();
			modbusConnection.WriteAnalogSignalValue(Rtu.RTUData.ID, SignalAddress, NewValue);
		}
		/// <summary>
		/// Find previous signal value
		/// </summary>
		private int ReadPreviousValue()
		{
			return Rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
