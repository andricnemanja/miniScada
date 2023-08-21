namespace Contracts.DTO
{
	public class RtuFlagDTO
	{
		public RtuFlagDTO(int rtuId, int flagId, RtuFlagOperation operation)
		{
			RtuId = rtuId;
			FlagId = flagId;
			Operation = operation;
		}

		public int RtuId { get; }
		public int FlagId { get; }
		public RtuFlagOperation Operation { get; set; }
	}
}
