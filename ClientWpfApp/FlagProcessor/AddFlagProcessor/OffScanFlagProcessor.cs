using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;

namespace ClientWpfApp.FlagProcessor.AddFlagProcessor
{
	public class OffScanFlagProcessor : IFlagProcessor
	{
		private readonly IRtuCache rtuCache;

		public OffScanFlagProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			RTU rtu = rtuCache.FindRtu(rtuId);
			rtu.OffScan = true;
			rtuCache.AddFlagToRtu(rtuId, flag);
		}
	}
}
