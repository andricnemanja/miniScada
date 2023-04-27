using System;
using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager.ResultsProcessing
{
	public sealed class ReadSingleAnalogSignalResultProcessor : ICommandResultProcessor
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
			ReadSingleAnalogSignalResult commandData = (ReadSingleAnalogSignalResult)commandResult;
			AnalogSignal signal = (AnalogSignal)rtuCache.GetSignal(commandData.RtuId, commandData.SignalId);

			string signalCacheValue = dynamicCacheClient.GetSignalValue(signal);

			if(signalCacheValue == string.Empty)
			{
				dynamicCacheClient.ChangeSignalValue(signal, commandData.SignalValue.ToString());
				dynamicCacheClient.PublishSignalChange(signal, commandData.SignalValue.ToString());
				return;
			}

			double.TryParse(signalCacheValue, out double currentSignalValue);

			if (Math.Abs(currentSignalValue - commandData.SignalValue) > signal.Deadband) 
			{ 
				dynamicCacheClient.ChangeSignalValue(signal, commandData.SignalValue.ToString());
				dynamicCacheClient.PublishSignalChange(signal, commandData.SignalValue.ToString());
			}
		}
	}
}
