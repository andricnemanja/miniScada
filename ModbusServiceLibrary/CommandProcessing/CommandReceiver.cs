using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	public class CommandReceiver : ICommandReceiver
	{
		private readonly Dictionary<Type, ICommandProcessor> commandProcessors = new Dictionary<Type, ICommandProcessor>()
		{
			{typeof(ReadSingleCoilCommand), new ReadSingleCoilCommandProcessor() },
			{typeof(ReadSingleHoldingRegisterCommand), new ReadSingleHoldingRegisterCommandProcessor() }
		};

		public ICommandResult ReceiveCommand(IRtuCommand command)
		{
			return commandProcessors[command.GetType()].ProccessCommand(command);
		}
	}
}
