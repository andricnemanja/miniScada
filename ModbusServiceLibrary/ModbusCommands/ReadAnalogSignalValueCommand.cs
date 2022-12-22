using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Class that defines command for reading analog signal values.
	/// </summary>
	public sealed class ReadAnalogSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Number unique to the RTU.
		/// </summary>
		private readonly int rtuId;
		/// <summary>
		/// Addres of the specific signal.
		/// </summary>
		private readonly int signalAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="ReadAnalogSignalValueCommand"/>.
		/// </summary>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class.</param>
		/// <param name="NewValue">Value that needs to be written.</param>
		/// <param name="signalAddress">Address of the signal that needs to be read.</param>
		public ReadAnalogSignalValueCommand(IModbusSimulatorClient modbusSimulatorClient, int rtuId, int signalAddress)
			: base(modbusSimulatorClient)
		{
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}

		/// <summary>
		/// Attribute containing value that has been read.
		/// </summary>
		public int NewValue { get; private set; }
		
		/// <summary>
		/// Executing the command for reading analog signal value.
		/// </summary>
		public override bool Execute()
		{
			if(!modbusSimulatorClient.TryReadAnalogInput(rtuId, signalAddress, out int value))
				return false;

			NewValue = value;
			return true;
		}
	}
}
