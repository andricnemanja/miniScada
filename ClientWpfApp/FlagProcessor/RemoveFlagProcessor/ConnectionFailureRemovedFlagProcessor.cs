using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;

namespace ClientWpfApp.FlagProcessor.RemoveFlagProcessor
{
	public class ConnectionFailureRemovedFlagProcessor : IFlagProcessor
	{
		private readonly IRtuCache rtuCache;

		public ConnectionFailureRemovedFlagProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			RTU rtu = rtuCache.FindRtu(rtuId);
			rtu.IsConnected = true;
			rtuCache.RemoveFlagFromRtu(rtuId, flag);
		}
	}
}
