using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class ConnectionFailureResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public ConnectionFailureResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
