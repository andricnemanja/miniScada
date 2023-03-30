using System;
using System.Collections.Generic;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public class CommandResultReceiver : ICommandResultReceiver
	{
		private readonly Dictionary<Type, ICommandResultProcessor> commandResultProcessors;

		public CommandResultReceiver(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.commandResultProcessors = new Dictionary<Type, ICommandResultProcessor>()
			{
				{typeof(ReadSingleAnalogSignalResult), new ReadSingleAnalogSignalResultProcessor(rtuCache, dynamicCacheClient) },
				{typeof(ReadSingleDiscreteSignalResult), new ReadSingleDiscreteSignalResultProcessor(dynamicCacheClient) }
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
