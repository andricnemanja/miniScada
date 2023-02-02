using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ReadSingleCoilResult : ICommandResult
	{
		[DataMember]
		public int RtuId { get; set;  }
		[DataMember]
		public CommandStatus CommandStatus { get; set; }
		[DataMember]
		public int CoilAddress { get; set; }
		[DataMember]
		public string CoilState { get; set; }

		public ReadSingleCoilResult(int rtuId, CommandStatus commandStatus, int coilAddress, string coilState)
		{
			RtuId = rtuId;
			CommandStatus = commandStatus;
			CoilAddress = coilAddress;
			CoilState = coilState;
		}
	}
}
