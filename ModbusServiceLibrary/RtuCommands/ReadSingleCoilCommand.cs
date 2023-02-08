namespace ModbusServiceLibrary.RtuCommands
{
	public class ReadSingleCoilCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int CoilAddress { get;  }
		//public int NumberOfCoils { get; }
		//public int MappingId { get; set; }

		public ReadSingleCoilCommand(int rtuId, int coilAddress)
		{
			RtuId = rtuId;
			CoilAddress = coilAddress;
			//NumberOfCoils = numberOfCoils;
			//MappingId = mappingId;
		}
	}
}
