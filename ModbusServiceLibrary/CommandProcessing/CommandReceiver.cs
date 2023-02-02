using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary
{
	public class CommandReceiver : ICommandReceiver
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;
		private readonly Dictionary<Type, ICommandProcessor> commandProcessors;

		public CommandReceiver(IModbusClient2 modbusClient, ISignalMapper signalMapper)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
			this.commandProcessors = new Dictionary<Type, ICommandProcessor>()
			{
				{typeof(ConnectToRtuCommand), new ConnectoToRtuCommandProcessor(modbusClient) },
				{typeof(ReadSingleCoilCommand), new ReadSingleCoilCommandProcessor(modbusClient, signalMapper) },
				{typeof(ReadSingleHoldingRegisterCommand), new ReadSingleHoldingRegisterCommandProcessor() }
			};
		}

		public ICommandResult ReceiveCommand(IRtuCommand command)
		{
			return commandProcessors[command.GetType()].ProcessCommand(command);
		}
	}
}
