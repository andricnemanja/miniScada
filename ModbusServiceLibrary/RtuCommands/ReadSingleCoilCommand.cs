namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleCoilCommand : IRtuCommand
	{
		public int RtuId { get; private set; }
		public int CoilAddress { get; private set; }

		public ReadSingleCoilCommand(int rtuId, int coilAddress)
		{
			RtuId = rtuId;
			CoilAddress = coilAddress;
		}
	}
}
