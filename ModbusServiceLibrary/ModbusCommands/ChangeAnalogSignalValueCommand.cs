using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ChangeAnalogSignalValueCommand : ModbusCommand
	{
		private readonly int newValue;
		private readonly int rtuId;
		private readonly int signalAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="ChangeAnalogSignalValueCommand"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		/// <param name="newValue">Value that needs to be written</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned</param>
		public ChangeAnalogSignalValueCommand(IModbusConnection modbusConnection, int newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			this.newValue = newValue;
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}

		public override void Execute()
		{
			modbusConnection.TryWriteAnalogSignalValue(rtuId, signalAddress, newValue);
		}
	}
}
