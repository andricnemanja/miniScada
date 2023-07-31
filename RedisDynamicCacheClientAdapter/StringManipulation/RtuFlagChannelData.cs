using Contracts.DTO;

namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	public class RtuFlagChannelData
	{
		public RtuFlagChannelData(int rtuId)
		{
			RtuId = rtuId;
			Operation = RtuFlagOperation.Add;
		}

		public int RtuId { get; set; }
		public RtuFlagOperation Operation { get; set; }
	}
}