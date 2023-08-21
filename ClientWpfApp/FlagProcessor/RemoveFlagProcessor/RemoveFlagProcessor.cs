using System.Collections.Generic;
using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.FlagProcessor.RemoveFlagProcessor
{
	public sealed class RemoveFlagProcessor
	{
		private readonly Dictionary<string, IFlagProcessor> flagNameToFlagProcessor;

		public RemoveFlagProcessor(IRtuCache rtuCache)
		{
			flagNameToFlagProcessor = new Dictionary<string, IFlagProcessor>()
			{
				{ "Connection Failure", new ConnectionFailureRemovedFlagProcessor(rtuCache) },
				{ "Off Scan", new OffScanRemovedFlagProcessor(rtuCache) }
			};
		}

		public void ProcessFlag(Flag flag, int rtuId)
		{
			if(flagNameToFlagProcessor.TryGetValue(flag.Name, out IFlagProcessor flagProcessor))
			{
				flagProcessor.ProcessFlag(flag, rtuId);
				return;
			}
		}
	}
}
