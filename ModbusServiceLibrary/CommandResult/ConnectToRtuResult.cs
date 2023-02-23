using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ConnectToRtuResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }


		public ConnectToRtuResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
