using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;

namespace ClientWpfApp.FlagProcessor.RemoveFlagProcessor
{
	public class OffScanRemovedFlagProcessor : IFlagProcessor
	{
		private readonly IRtuCache rtuCache;

		public OffScanRemovedFlagProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			RTU rtu = rtuCache.FindRtu(rtuId);
			rtu.OffScan = false;
			rtuCache.RemoveFlagFromRtu(rtuId, flag);
		}
	}
}
