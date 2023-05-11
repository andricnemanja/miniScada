using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ConnectoToRtuCommandProcessor : ICommandProcessor
	{
		private readonly IProtocolDriver protocolDriver;
		private readonly IModbusRtuConfiguration rtuConfiguration;

		public ConnectoToRtuCommandProcessor(IProtocolDriver protocolDriver, IModbusRtuConfiguration rtuConfiguration)
		{
			this.protocolDriver = protocolDriver;
			this.rtuConfiguration = rtuConfiguration;
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			ConnectToRtuCommand connectToRtuCommand = (ConnectToRtuCommand)command;
			RTUConnectionParameters connectionParameters = rtuConfiguration.GetRtuConnectionParameters(connectToRtuCommand.RtuId);

			if (protocolDriver.TryConnectToRtu(connectToRtuCommand.RtuId, connectionParameters.IpAddress, connectionParameters.Port))
			{
				return new ConnectToRtuResult(connectToRtuCommand.RtuId);
			}
			return new ConnectToRtuFailedResult(connectToRtuCommand.RtuId);
		}
	}
}
