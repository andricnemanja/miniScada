using System.Runtime.Serialization;

namespace DynamicCacheManager.CommandResult
{
	[DataContract]
	[KnownType(typeof(ConnectToRtuResult))]
	[KnownType(typeof(ConnectToRtuFailedResult))]
	[KnownType(typeof(ReadSingleDiscreteSignalResult))]
	[KnownType(typeof(ReadSingleDiscreteSignalFailedResult))]
	[KnownType(typeof(ReadSingleAnalogSignalResult))]
	[KnownType(typeof(ReadSingleAnalogSignalFailedResult))]
	[KnownType(typeof(WriteDiscreteSignalCommandResult))]
	[KnownType(typeof(WriteAnalogSignalCommandResult))]
	public class CommandResultBase
	{
	}
}
