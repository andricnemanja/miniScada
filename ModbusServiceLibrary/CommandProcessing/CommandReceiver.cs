using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary
{
	public class CommandReceiver : ICommandReceiver
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;
		private readonly IRtuConfiguration rtuConfiguration;
		private readonly Dictionary<Type, ICommandProcessor> commandProcessors;

		public CommandReceiver(IModbusClient2 modbusClient, ISignalMapper signalMapper, IRtuConfiguration rtuConfiguration)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
			this.rtuConfiguration = rtuConfiguration;
			this.commandProcessors = new Dictionary<Type, ICommandProcessor>()
			{
				{typeof(ConnectToRtuCommand), new ConnectoToRtuCommandProcessor(modbusClient, rtuConfiguration) },
				{typeof(ReadSingleCoilCommand), new ReadSingleCoilCommandProcessor(modbusClient, signalMapper, rtuConfiguration) },
				{typeof(ReadSingleHoldingRegisterCommand), new ReadSingleHoldingRegisterCommandProcessor() }
			};
		}

		public ICommandResult ReceiveCommand(IRtuCommand command)
		{
			if (commandProcessors.TryGetValue(command.GetType(), out ICommandProcessor commandProcessor))
			{
				return commandProcessor.ProcessCommand(command);
			}
			return null;
		}
	}
}
