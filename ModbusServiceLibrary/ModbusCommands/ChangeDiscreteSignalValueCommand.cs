using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Defining command for changing discrete signal value.
	/// </summary>
	public sealed class ChangeDiscreteSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Value that needs to be written.
		/// </summary>
		private bool newValue;

		/// <summary>
		/// Number unique to the RTU.
		/// </summary>
		private readonly int rtuId;

		/// <summary>
		/// Address of the signal.
		/// </summary>
		private readonly int signalAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="ChangeDiscreteSignalValueCommand"/>.
		/// </summary>
		/// <param name="modbusConnection">Instance of the <see cref="IModbusConnection"/> class.</param>
		/// <param name="newValue">Value that needs to be written.</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned.</param>
		public ChangeDiscreteSignalValueCommand(IModbusConnection modbusConnection, bool newValue, int rtuId, int signalAddress)
			: base(modbusConnection)
		{
			this.newValue = newValue;
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}

		/// <summary>
		/// Executing the command for writing discrete signal value.
		/// </summary>
		public override void Execute()
		{
			modbusConnection.TryWriteDiscreteSignalValue(rtuId, signalAddress, newValue);
		}
	}
}
