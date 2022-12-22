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
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class.</param>
		/// <param name="newValue">Value that needs to be written.</param>
		/// <param name="signalAddress">Address of the signal to which the new value should be assigned.</param>
		public ChangeDiscreteSignalValueCommand(IModbusSimulatorClient modbusSimulatorClient, bool newValue, int rtuId, int signalAddress)
			: base(modbusSimulatorClient)
		{
			this.newValue = newValue;
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}
		
		/// <summary>
		/// Executing the command for writing discrete signal value.
		/// </summary>
		public override bool Execute()
		{
			return modbusSimulatorClient.TryWriteDiscreteSignalValue(rtuId, signalAddress, newValue);
		}
	}
}
