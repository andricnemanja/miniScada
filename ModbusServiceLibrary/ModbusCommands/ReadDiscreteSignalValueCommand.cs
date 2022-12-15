using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ReadDiscreteSignalValueCommand : ModbusCommand
	{
		private readonly int rtuId;
		private readonly int signalAddress;

		public ReadDiscreteSignalValueCommand(IModbusConnection modbusConnection, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}
		public bool NewValue { get; set; }

		public override void Execute()
		{
			modbusConnection.TryReadDiscreteInput(rtuId, signalAddress, out bool value);
			NewValue = value;
		}
	}
}
