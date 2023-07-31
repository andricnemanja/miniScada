using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that puts RTU in OnScan state
	/// </summary>
	[DataContract]
	public class RtuOnScanCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public RtuOnScanCommand(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
