using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;

namespace ModbusServiceLibrary
{
	public class CommandReceiver : ICommandReceiver
	{
		private readonly Dictionary<Type, ICommandProcessor> commandProcessors;

		public CommandReceiver(IModbusRtuConfiguration rtuConfiguration, IProtocolDriver protocolDriver)
		{
			this.commandProcessors = new Dictionary<Type, ICommandProcessor>()
			{
				{typeof(ConnectToRtuCommand), new ConnectoToRtuCommandProcessor(protocolDriver, rtuConfiguration) },
				{typeof(ReadSingleSignalCommand), new ReadSingleSignalCommandProcessor(protocolDriver, rtuConfiguration) },
				{typeof(WriteAnalogSignalCommand), new WriteAnalogSignalCommandProcessor(protocolDriver) },
				{typeof(WriteDiscreteSignalCommand), new WriteDiscreteSignalCommandProcessor(protocolDriver) }
			};
		}

		public CommandResultBase ReceiveCommand(IRtuCommand command)
		{
			if (commandProcessors.TryGetValue(command.GetType(), out ICommandProcessor commandProcessor))
			{
				return commandProcessor.ProcessCommand(command);
			}
			return new CommandProcessorNotFoundResult(command);
		}
	}
}
