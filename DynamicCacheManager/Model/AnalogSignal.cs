using System.Collections.Generic;

namespace DynamicCacheManager.Model
{
	public class AnalogSignal : ISignal
	{
		public AnalogSignal(int id, int rtuId, double deadband)
		{
			Id = id;
			RtuId = rtuId;
			Deadband = deadband;
			Value = string.Empty;
		}
		public int Id { get; }
		public int RtuId { get; }
		public double Deadband { get; }
		public string Value { get; set; }
		public List<int> Flags { get; set; }
	}
}
