using System;

namespace DynamicCacheManager.Model
{
	public class DiscreteSignal : ISignal
	{
		public DiscreteSignal(int id, int rtuId, TimeSpan staleTime)
		{
			Id = id;
			RtuId = rtuId;
			StaleTime = staleTime;
		}

		public int Id { get; }
		public int RtuId { get; }
		public TimeSpan StaleTime { get; }

	}
}
