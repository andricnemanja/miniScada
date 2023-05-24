using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever we need to establish the connection with the RTU.
	/// </summary>
	[DataContract]
	public class ConnectToRtuCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public ConnectToRtuCommand(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
