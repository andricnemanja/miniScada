using ClientWpfApp.Model;
using ModbusServiceLibrary.CommandResult;

namespace ClientWpfApp.ModbusCallback
{
	public class ReadSingleDiscreteSignalResultProcessor : ICommandResultProcessor
	{
		private readonly IRtuCache rtuCache;

		public ReadSingleDiscreteSignalResultProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessCommandResult(CommandResultBase commandResult)
		{
			ReadSingleDiscreteSignalResult readCommandResult = (ReadSingleDiscreteSignalResult)commandResult;
			rtuCache.UpdateDiscreteSignalValue(readCommandResult.RtuId, readCommandResult.SignalId, readCommandResult.State);
		}
	}
}
