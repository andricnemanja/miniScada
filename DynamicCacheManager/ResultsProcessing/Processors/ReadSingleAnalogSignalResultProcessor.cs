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

			string signalCacheValue = dynamicCacheClient.GetSignalValue(commandData.RtuId, commandData.SignalId);
			double deadband = dynamicCacheClient.GetAnalogSignalDeadband(commandData.RtuId, commandData.SignalId);

			if(!double.TryParse(signalCacheValue, out double currentSignalValue))
			{
				ChangeSignalValue(commandData);
			}
			else if(IsValueChangeAboveDeadband(currentSignalValue, commandData.SignalValue, deadband))
			{
				ChangeSignalValue(commandData);
			}
		}

		private void ChangeSignalValue(ReadSingleAnalogSignalResult commandData)
		{
			dynamicCacheClient.ChangeSignalValue(commandData.RtuId, commandData.SignalId, commandData.SignalValue.ToString());
			dynamicCacheClient.PublishSignalChange(commandData.RtuId, commandData.SignalId, typeof(AnalogSignal).Name, commandData.SignalValue.ToString());
		}

		private bool IsValueChangeAboveDeadband(double currentSignalValue, double newValue, double deadband)
		{
			return Math.Abs(currentSignalValue - newValue) > deadband;
		}
	}
}
