using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class RtuOnScanResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public RtuOnScanResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
