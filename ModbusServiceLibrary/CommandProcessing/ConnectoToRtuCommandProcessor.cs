using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ConnectoToRtuCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;

		public ConnectoToRtuCommandProcessor(IModbusClient2 modbusClient)
		{
			this.modbusClient = modbusClient;
		}

		public ICommandResult ProcessCommand(object command)
		{
			ConnectToRtuCommand connectToRtuCommand = (ConnectToRtuCommand)command;
			if(modbusClient.TryConnect(connectToRtuCommand.RtuId, connectToRtuCommand.IpAddress, connectToRtuCommand.Port))
			{
				return new ConnectToRtuResult(connectToRtuCommand.RtuId, CommandStatus.Executed);
			}
			return new ConnectToRtuResult(connectToRtuCommand.RtuId, CommandStatus.Failed);
		}
	}
}
