using System.Collections.Generic;
using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.FlagProcessor.AddFlagProcessor
{
	public sealed class AddFlagProcessor
	{
		private readonly Dictionary<string, IFlagProcessor> flagNameToFlagProcessor;

		public AddFlagProcessor(IRtuCache rtuCache)
		{
			flagNameToFlagProcessor = new Dictionary<string, IFlagProcessor>()
			{
				{"Connection Failure", new ConnectionFailureFlagProcessor(rtuCache) }
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
