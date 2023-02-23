﻿using ModbusServiceLibrary.CommandResult;
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
			ReadSingleSignalCommandResult connectToRtuCommand = (ReadSingleSignalCommandResult)command;
			RTUConnectionParameters connectionParameters = rtuConfiguration.GetRtuConnectionParameters(connectToRtuCommand.RtuId);

			if (modbusClient.TryConnect(connectToRtuCommand.RtuId, connectionParameters.IpAddress, connectionParameters.Port))
			{
				return new ConnectToRtuResult(connectToRtuCommand.RtuId);
			}
			return new ConnectToRtuFailedResult(connectToRtuCommand.RtuId);
		}
	}
}
