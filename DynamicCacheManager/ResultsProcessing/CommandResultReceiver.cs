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

		public CommandResultReceiver(IServiceRtuCache rtuCache, IServiceFlagCache serviceFlagCache, IDynamicCacheClient dynamicCacheClient)
		{
			commandResultProcessors = new Dictionary<Type, ICommandResultProcessor>()
			{
				{typeof(ReadSingleAnalogSignalResult), new ReadSingleAnalogSignalResultProcessor(rtuCache, dynamicCacheClient) },
				{typeof(ReadSingleAnalogSignalFailedResult), new ReadSingleAnalogSignalFailedResultProcessor(rtuCache, serviceFlagCache, dynamicCacheClient) },
				{typeof(ReadSingleDiscreteSignalFailedResult), new ReadSingleDiscreteSignalFailedResultProcessor(rtuCache, serviceFlagCache, dynamicCacheClient) },
				{typeof(ReadSingleDiscreteSignalResult), new ReadSingleDiscreteSignalResultProcessor(rtuCache, dynamicCacheClient) },
				{ typeof(ConnectToRtuResult), new ConnectToRtuResultProcessor(rtuCache, serviceFlagCache, dynamicCacheClient) },
				{ typeof(ConnectionFailureResult), new ConnectionFailureResultProcessor(serviceFlagCache, dynamicCacheClient) },
				{ typeof(RtuOffScanResult), new RtuOffScanResultProcessor(serviceFlagCache, dynamicCacheClient) },
				{ typeof(RtuOnScanResult), new RtuOnScanResultProcessor(serviceFlagCache, dynamicCacheClient) }
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
