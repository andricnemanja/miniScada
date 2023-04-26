using System;

namespace DynamicCacheManager.Model
{
	public class AnalogSignal : ISignal
	{
		public AnalogSignal(int id, int rtuId, double deadband, TimeSpan staleTime)
		{
			Id = id;
			RtuId = rtuId;
			Deadband = deadband;
			StaleTime = staleTime;
		}
		public int Id { get; }
		public int RtuId { get; }
		public TimeSpan StaleTime { get; }
		public double Deadband { get; }
	}
}
