using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
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
	[KnownType(typeof(CommandProcessorNotFoundResult))]
	[KnownType(typeof(ConnectionFailureResult))]
	[KnownType(typeof(RtuOnScanResult))]
	[KnownType(typeof(RtuOffScanResult))]
	public class CommandResultBase
	{
	}
}
