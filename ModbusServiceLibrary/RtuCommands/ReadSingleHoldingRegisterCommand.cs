namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleHoldingRegisterCommand : IRtuCommand
	{
		public int RtuId { get; set; }
		public int RegisterAddress { get; set; }
	}
}
