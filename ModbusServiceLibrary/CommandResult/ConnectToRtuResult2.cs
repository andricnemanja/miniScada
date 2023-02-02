using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ConnectToRtuResult2
	{
		[DataMember]
		public int RtuId { get; set; }
		public CommandStatus CommandStatus { get; set; }

		public ConnectToRtuResult2(int rtuId, CommandStatus commandStatus)
		{
			RtuId = rtuId;
			CommandStatus = commandStatus;
		}
	}
}
