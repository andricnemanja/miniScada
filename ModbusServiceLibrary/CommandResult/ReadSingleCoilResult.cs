namespace ModbusServiceLibrary.CommandResult
{
	public class ReadSingleCoilResult : ICommandResult
	{
		public int RtuId { get; set; }
		public int CoilAddress { get; set; }
		public string CoilState { get; set; }
	}
}
