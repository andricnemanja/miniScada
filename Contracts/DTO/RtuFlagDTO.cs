namespace Contracts.DTO
{
	public class RtuFlagDTO
	{
		public RtuFlagDTO(int rtuId, string flagName, RtuFlagOperation operation)
		{
			RtuId = rtuId;
			FlagName = flagName;
			Operation = operation;
		}

		public int RtuId { get; }
		public string FlagName { get; }
		public RtuFlagOperation Operation { get; set; }
	}
}
