using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	public class ConnectToRtuFailedResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }


		public ConnectToRtuFailedResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
