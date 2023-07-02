namespace DynamicCacheManager.Model
{
	public class DiscreteSignal : ISignal
	{
		public DiscreteSignal(int id, int rtuId)
		{
			Id = id;
			RtuId = rtuId;
			Value = string.Empty;
		}

		public int Id { get; }
		public int RtuId { get; }
		public string Value { get; set; }

	}
}
