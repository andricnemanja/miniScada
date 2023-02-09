using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	[KnownType(typeof(ReadSingleDiscreteSignalResult))]
	[KnownType(typeof(ReadSingleAnalogSignalResult))]
	[KnownType(typeof(WriteDiscreteSignalCommandResult))]
	public class CommandResultBase
	{
		[DataMember]
		public int RtuId { get; set; }

		public CommandResultBase(int rtuId)
		{
			RtuId = rtuId;
		}
	}
}
