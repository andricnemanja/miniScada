namespace DynamicCacheManager.Model
{
	public class AnalogSignal : ISignal
	{
		public AnalogSignal(int id, int rtuId, double deadband)
		{
			Id = id;
			RtuId = rtuId;
			Deadband = deadband;
		}
		public int Id { get; }
		public int RtuId { get; }
		public double Deadband { get; }
	}
}
