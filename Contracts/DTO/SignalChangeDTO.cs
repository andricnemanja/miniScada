namespace Contracts.DTO
{
	public class SignalChangeDTO
	{
		public int RtuId { get; set; }
		public int SignalId { get; set; }
		public string NewValue { get; set; }

		public SignalChangeDTO(int rtuId, int signalId, string newValue)
		{
			RtuId = rtuId;
			SignalId = signalId;
			NewValue = newValue;
		}
	}
}
