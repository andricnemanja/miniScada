namespace Contracts.DTO
{
	/// <summary>
	/// DTO class that holds signal value
	/// </summary>
	public class SignalValueDTO
	{
		public int SignalId { get; set; }
		public string Value { get; set; }

		public SignalValueDTO(int signalId, string value)
		{
			SignalId = signalId;
			Value = value;
		}
	}
}
