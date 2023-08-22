namespace Contracts.DTO
{
	public class SignalFlagDTO
	{
		public SignalFlagDTO(int rtuId, int signalId, int flagId, RtuFlagOperation operation)
		{
			RtuId = rtuId;
			SignalId = signalId;
			FlagId = flagId;
			Operation = operation;
		}

		public int RtuId { get; }
		public int SignalId { get; }
		public int FlagId { get; }
		public RtuFlagOperation Operation { get; set; }
	}
}
