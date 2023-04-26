using System;

namespace DynamicCacheManager.Model
{
	public interface ISignal
	{
		int Id { get; }
		int RtuId { get; }
		TimeSpan StaleTime { get; }
	}
}