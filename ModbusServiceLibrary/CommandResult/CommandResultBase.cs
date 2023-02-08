using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	[KnownType(typeof(ReadSingleCoilResult))]
	public class CommandResultBase
	{
		public int RtuId { get; set; }
	}
}
