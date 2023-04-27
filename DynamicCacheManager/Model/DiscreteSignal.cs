namespace DynamicCacheManager.Model
{
	public class DiscreteSignal : ISignal
	{
		public DiscreteSignal(int id, int rtuId)
		{
			Id = id;
			RtuId = rtuId;
		}

		public int Id { get; }
		public int RtuId { get; }

	}
}
