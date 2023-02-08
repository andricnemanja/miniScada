using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ConnectToRtuResult : CommandResultBase
	{
		[DataMember]
		public CommandStatus CommandStatus { get; set; }

		public ConnectToRtuResult(int rtuId, CommandStatus commandStatus) : base(rtuId)
		{
			RtuId = rtuId;
			CommandStatus = commandStatus;
		}
	}
}
