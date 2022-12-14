using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ChangeDiscreteSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ChangeDiscreteSignalValueCommand"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		/// <param name="newValue">Value that needs to be written</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned</param>
		public ChangeDiscreteSignalValueCommand(IModbusConnection modbusConnection, bool newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			NewValue = newValue;
			Rtu = modbusConnection.FindRtu(rtuId);
			SignalAddress = signalAddress;
		}
		public bool PreviousValue { get; set; }
		public bool NewValue { get; set; }
		public RTU Rtu { get; set; }
		public int SignalAddress { get; set; }

		public override void Execute()
		{
			PreviousValue = ReadPreviousValue();
			modbusConnection.WriteDiscreteSignalValue(Rtu.RTUData.ID, SignalAddress, NewValue);
		}
		/// <summary>
		/// Find previous signal value
		/// </summary>
		private bool ReadPreviousValue()
		{
			return Rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == SignalAddress).FirstOrDefault().Value;
		}
	}
}
