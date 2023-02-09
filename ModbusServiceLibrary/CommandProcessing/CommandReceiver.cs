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
		private readonly Dictionary<Type, ICommandProcessor> commandProcessors;

		public CommandReceiver(IModbusClient2 modbusClient, ISignalMapper signalMapper, IRtuConfiguration rtuConfiguration)
		{
			this.commandProcessors = new Dictionary<Type, ICommandProcessor>()
			{
				{typeof(ConnectToRtuCommand), new ConnectoToRtuCommandProcessor(modbusClient, rtuConfiguration) },
				{typeof(ReadSingleSignalCommand), new ReadSingleSignalCommandProcessor(modbusClient, signalMapper, rtuConfiguration) },
				{typeof(WriteAnalogSignalCommand), new WriteAnalogSignalCommandProcessor(modbusClient, rtuConfiguration, signalMapper) }
			};
		}

		public CommandResultBase ReceiveCommand(IRtuCommand command)
		{
			if (commandProcessors.TryGetValue(command.GetType(), out ICommandProcessor commandProcessor))
			{
				return commandProcessor.ProcessCommand(command);
			}
			return null;
		}
	}
}
