using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class RtuOffScanCommandProcessor : ICommandProcessor
	{
		private readonly IProtocolDriver protocolDriver;

		public RtuOffScanCommandProcessor(IProtocolDriver protocolDriver)
		{
			this.protocolDriver = protocolDriver;
		}

		public CommandResultBase ProcessCommand(RtuCommandBase command)
		{
			RtuOffScanCommand connectToRtuCommand = (RtuOffScanCommand)command;

			protocolDriver.DisconnectFromRtu(connectToRtuCommand.RtuId);
			return new RtuOffScanResult(connectToRtuCommand.RtuId);
		}
	}
}
