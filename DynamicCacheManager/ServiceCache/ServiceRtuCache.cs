using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public class ServiceRtuCache : IServiceRtuCache
	{
		public List<Rtu> RtuList { get; set; }
	}
}
