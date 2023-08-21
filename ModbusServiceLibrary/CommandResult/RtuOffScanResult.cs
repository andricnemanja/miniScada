using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class RtuOffScanResult : CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public RtuOffScanResult(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
