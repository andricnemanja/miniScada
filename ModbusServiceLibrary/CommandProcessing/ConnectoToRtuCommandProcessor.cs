using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ConnectoToRtuCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly IRtuConfiguration rtuConfiguration;

		public ConnectoToRtuCommandProcessor(IModbusClient2 modbusClient, IRtuConfiguration rtuConfiguration)
		{
			this.modbusClient = modbusClient;
			this.rtuConfiguration = rtuConfiguration;
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			ConnectToRtuCommand connectToRtuCommand = (ConnectToRtuCommand)command;
			RTUData rtuData = rtuConfiguration.FindRtuData(connectToRtuCommand.RtuId);
			if (modbusClient.TryConnect(rtuData.ID, rtuData.IpAddress, rtuData.Port))
			{
				return new ConnectToRtuResult(connectToRtuCommand.RtuId, CommandStatus.Executed);
			}
			return new ConnectToRtuResult(connectToRtuCommand.RtuId, CommandStatus.Failed);
		}
	}
}
