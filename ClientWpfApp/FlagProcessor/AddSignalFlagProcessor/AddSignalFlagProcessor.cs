using System.Collections.Generic;
using ClientWpfApp.Model;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.FlagProcessor.AddSignalFlagProcessor
{
	public sealed class AddSignalFlagProcessor
	{
		private readonly Dictionary<string, IFlagProcessor> flagNameToFlagProcessor;

		public AddSignalFlagProcessor(IRtuCache rtuCache)
		{
			flagNameToFlagProcessor = new Dictionary<string, IFlagProcessor>()
			{
				{ "Command Failed", new CommandFailedFlagProcessor(rtuCache) },
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
