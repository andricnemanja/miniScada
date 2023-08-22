using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;

namespace ClientWpfApp.FlagProcessor.AddSignalFlagProcessor
{
	public class CommandFailedFlagProcessor : IFlagProcessor
	{
		private readonly IRtuCache rtuCache;

		public CommandFailedFlagProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			RTU rtu = rtuCache.FindRtu(rtuId);
			rtuCache.AddFlagToRtu(rtuId, flag);
		}
	}
}
