using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public interface IServiceFlagCache
	{
		Dictionary<string, Flag> flagNameToFlag { get; }

		Flag GetFlag(string flagName);
		void InitializeData();
	}
}