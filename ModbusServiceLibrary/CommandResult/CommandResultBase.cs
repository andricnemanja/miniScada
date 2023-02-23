using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	[KnownType(typeof(ConnectToRtuResult))]
	[KnownType(typeof(ConnectToRtuFailedResult))]
	[KnownType(typeof(ReadSingleDiscreteSignalResult))]
	[KnownType(typeof(ReadSingleAnalogSignalResult))]
	[KnownType(typeof(WriteDiscreteSignalCommandResult))]
	[KnownType(typeof(WriteAnalogSignalCommandResult))]
	[KnownType(typeof(CommandProcessorNotFoundResult))]
	public class CommandResultBase
	{
	}
}
