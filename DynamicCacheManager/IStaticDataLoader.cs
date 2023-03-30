using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager
{
	public interface IStaticDataLoader
	{
		List<Rtu> InitializeData();
	}
}