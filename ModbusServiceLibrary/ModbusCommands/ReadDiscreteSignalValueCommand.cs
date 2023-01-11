using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Class that defines command for reading discrete signal values.
	/// </summary>
	public sealed class ReadDiscreteSignalValueCommand : ModbusCommand
	{
		/// <summary>
		/// Number unique to the RTU.
		/// </summary>
		private readonly int rtuId;
		/// <summary>
		/// Address of the specific signal.
		/// </summary>
		private readonly int signalAddress;

		/// <summary>
		/// Initializes a new instance of the <see cref="ReadDiscreteSignalValueCommand"/>.
		/// </summary>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class.</param>
		/// <param name="rtuId">Value that needs to be written.</param>
		/// <param name="signalAddress">Address of the signal that needs to be read.</param>
		public ReadDiscreteSignalValueCommand(IModbusSimulatorClient modbusSimulatorClient, int rtuId, int signalAddress)
			: base(modbusSimulatorClient)
		{
			this.rtuId = rtuId;
			this.signalAddress = signalAddress;
		}

		/// <summary>
		/// Attribute containing value that has been read.
		/// </summary>
		public bool[] NewValue { get; set; }

		/// <summary>
		/// Executing the command for reading discrete signal value.
		/// </summary>
		public override bool Execute()
		{
			if(!modbusSimulatorClient.TryReadDiscreteInput(rtuId, signalAddress, out bool[] values))
				return false;

			NewValue = values;
			return true;
		}
	}
}
