using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;

namespace ClientWpfApp.FlagProcessor.AddFlagProcessor
{
	public class ConnectionFailureFlagProcessor : IFlagProcessor
	{
		private readonly IRtuCache rtuCache;

		public ConnectionFailureFlagProcessor(IRtuCache rtuCache)
		{
			this.rtuCache = rtuCache;
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			RTU rtu = rtuCache.FindRtu(rtuId);
			rtu.IsConnected = false;
			rtuCache.AddFlagToRtu(rtuId, flag);
		}
	}
}
