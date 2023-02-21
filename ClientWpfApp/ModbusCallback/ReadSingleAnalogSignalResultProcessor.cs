using ClientWpfApp.Model;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public class ReadSingleAnalogSignalResultProcessor : ICommandResultProcessor
	{
		private readonly IRtuCache rtuCache;

		public ReadSingleAnalogSignalResultProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleAnalogSignalResult readSingleAnalogSignalResult = (ReadSingleAnalogSignalResult)commandResult;

			rtuCache.UpdateAnalogSignalValue(readSingleAnalogSignalResult.RtuId, readSingleAnalogSignalResult.SignalId, readSingleAnalogSignalResult.SignalValue);
		}
	}
}
