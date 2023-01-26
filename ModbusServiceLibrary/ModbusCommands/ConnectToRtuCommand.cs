using ModbusServiceLibrary.ModbusCommunication;

namespace ModbusServiceLibrary.ModbusCommands
{
	/// <summary>
	/// Class that defines command for reading analog signal values.
	/// </summary>
	public sealed class ConnectToRtuCommand : ModbusCommand
	{
		private readonly int rtuId;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectToRtuCommand"/>.
		/// </summary>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class.</param>
		public ConnectToRtuCommand(IModbusSimulatorClient modbusSimulatorClient, int rtuId)
			: base(modbusSimulatorClient)
		{
			this.rtuId = rtuId;
		}
		
		/// <summary>
		/// Executing the command connecting to RTU;
		/// </summary>
		public override bool Execute()
		{
			return modbusSimulatorClient.TryConnectToRtu(rtuId);
		}
	}
}
