namespace Contracts.DTO
{
	public class RtuFlagDTO
	{
		public RtuFlagDTO(int rtuId, string flagName)
		{
			RtuId = rtuId;
			FlagName = flagName;
		}

		public int RtuId { get; }
		public string FlagName { get; }
	}
}
