using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that disconnect service from RTU
	/// </summary>
	[DataContract]
	public class RtuOffScanCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public RtuOffScanCommand(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
