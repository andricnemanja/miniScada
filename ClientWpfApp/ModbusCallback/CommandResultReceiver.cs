﻿using System;
using System.Collections.Generic;
using ClientWpfApp.Model;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public class CommandResultReceiver : ICommandResultReceiver
	{
		private readonly Dictionary<Type, ICommandResultProcessor> commandResultProcessors;

		public CommandResultReceiver(IRtuCache rtuCache)
		{
			this.commandResultProcessors = new Dictionary<Type, ICommandResultProcessor>()
			{
				{typeof(ReadSingleAnalogSignalResult), new ReadSingleAnalogSignalResultProcessor(rtuCache) },
				{typeof(ReadSingleDiscreteSignalResult), new ReadSingleDiscreteSignalResultProcessor(rtuCache) }
			};
		}

		public void ReceiveCommandResult(CommandResultBase commandResult)
		{
			if (commandResultProcessors.TryGetValue(commandResult.GetType(), out ICommandResultProcessor processor))
			{
				processor.ProcessCommandResult(commandResult);
			}
		}

	}
}
