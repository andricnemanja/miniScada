using System;
using System.Collections.Generic;
using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class CommandResultReceiver : ICommandResultReceiver
	{
		private readonly Dictionary<Type, ICommandResultProcessor> commandResultProcessors;

		public CommandResultReceiver(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			commandResultProcessors = new Dictionary<Type, ICommandResultProcessor>()
			{
				{typeof(ReadSingleAnalogSignalResult), new ReadSingleAnalogSignalResultProcessor(rtuCache, dynamicCacheClient) },
				{typeof(ReadSingleAnalogSignalFailedResult), new ReadSingleAnalogSignalFailedResultProcessor(rtuCache, dynamicCacheClient) },
				{typeof(ReadSingleDiscreteSignalResult), new ReadSingleDiscreteSignalResultProcessor(rtuCache, dynamicCacheClient) },
				{ typeof(ConnectToRtuResult), new ConnectToRtuResultProcessor(rtuCache, dynamicCacheClient) }
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
