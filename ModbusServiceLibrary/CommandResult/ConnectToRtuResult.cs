using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ConnectToRtuResult : ICommandResult
	{
		[DataMember]
		public int RtuId { get; set; }
		[DataMember]
		public CommandStatus CommandStatus { get; set; }

		public ConnectToRtuResult(int rtuId, CommandStatus commandStatus)
		{
			RtuId = rtuId;
			CommandStatus = commandStatus;
		}
	}
}
