using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public interface IStaticDataLoader
	{
		List<Rtu> InitializeRtuData();
		Dictionary<string, Flag> InitializeFlagData();
	}
}