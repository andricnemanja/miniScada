using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public class ReadSingleAnalogSignalResultProcessor : ICommandResultProcessor
	{
		private readonly IServiceRtuCache rtuCache;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public ReadSingleAnalogSignalResultProcessor(IServiceRtuCache rtuCache, IDynamicCacheClient dynamicCacheClient)
		{
			this.rtuCache = rtuCache;
			this.dynamicCacheClient = dynamicCacheClient;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleAnalogSignalResult readSingleAnalogSignalResult = (ReadSingleAnalogSignalResult)commandResult;

			dynamicCacheClient.ChangeSignalValue(readSingleAnalogSignalResult.RtuId, readSingleAnalogSignalResult.SignalId, readSingleAnalogSignalResult.SignalValue);
		}
	}
}
