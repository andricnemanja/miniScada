using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Defining command for changing analog signal value.
	/// </summary>
	public sealed class ChangeAnalogSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Value that needs to be written.
		/// </summary>
		private readonly int newValue;

		/// <summary>
		/// Number unique to the RTU.
		/// </summary>
		private readonly int rtuId;

		/// <summary>
		/// Address of the signal.
		/// </summary>
		private readonly int signalAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="ChangeAnalogSignalValueCommand"/> class.
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class.</param>
		/// <param name="newValue">Value that needs to be written.</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned.</param>
		public ChangeAnalogSignalValueCommand(IModbusConnection modbusConnection, int newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			this.newValue = newValue;
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}

		/// <summary>
		/// Executing the command for writing analog signal value. 
		/// </summary>
		public override void Execute()
		{
			modbusConnection.TryWriteAnalogSignalValue(rtuId, signalAddress, newValue);
		}
	}
}
