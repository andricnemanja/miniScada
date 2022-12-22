using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	public sealed class ReadAnalogSignalValueCommand : ModbusCommand
	{
		private readonly int rtuId;
		private readonly int signalAddress;
		/// <summary>
		/// Initializes a new instance of the <see cref="ReadAnalogSignalValueCommand"/>
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class</param>
		/// <param name="NewValue">Value that needs to be written</param>
		/// <param name="signalAddress">Address of the signal that needs to be read</param>
		public ReadAnalogSignalValueCommand(IModbusConnection modbusConnection, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}
		public int NewValue { get; private set; }

		public override bool Execute()
		{
			if(!modbusConnection.TryReadAnalogInput(rtuId, signalAddress, out int value))
				return false;

			NewValue = value;
			return true;
		}
	}
}
