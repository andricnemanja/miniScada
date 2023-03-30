namespace DynamicCacheManager.Model
{
	public class AnalogSignal
	{
		public int Id { get; }
		public int RtuId { get; set; }
		public double Deadband { get; }

		public AnalogSignal(int id, int rtuId, double deadband)
		{
			Id = id;
			RtuId = rtuId;
			Deadband = deadband;
		}
	}
}
