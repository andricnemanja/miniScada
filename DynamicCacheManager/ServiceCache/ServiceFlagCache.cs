using System.Collections.Generic;
using DynamicCacheManager.Model;
using DynamicCacheManager.Model.NullObjects;

namespace DynamicCacheManager.ServiceCache
{
	public class ServiceFlagCache : IServiceFlagCache
	{
		private readonly IStaticDataLoader staticDataLoader;
		public ServiceFlagCache(IStaticDataLoader staticDataLoader)
		{
			this.staticDataLoader = staticDataLoader;
		}

		public Dictionary<string, Flag> flagNameToFlag { get; private set; }

		public void InitializeData()
		{
			flagNameToFlag = staticDataLoader.InitializeFlagData();
		}

		public Flag GetFlag(string flagName)
		{
			if (flagNameToFlag.TryGetValue(flagName, out var flag))
			{
				return flag;
			}
			return new NullFlag(-1, "");
		}
	}
}
