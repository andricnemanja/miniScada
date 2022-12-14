using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ReadAnalogSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ReadAnalogSignalValueCommand"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		/// <param name="newValue">Value that needs to be written</param>
		/// <param name="signalAddress">Address of the signal that needs to be read</param>
		public ReadAnalogSignalValueCommand(IModbusConnection modbusConnection, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
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
			NewValue = modbusConnection.ReadRegister(Rtu.RTUData.ID, SignalAddress);
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
