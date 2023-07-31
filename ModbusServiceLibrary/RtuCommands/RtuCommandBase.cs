using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	[DataContract]
	[KnownType(typeof(RtuOnScanCommand))]
	[KnownType(typeof(ReadSingleSignalCommand))]
	[KnownType(typeof(WriteAnalogSignalCommand))]
	[KnownType(typeof(WriteDiscreteSignalCommand))]
	public class RtuCommandBase
	{
	}
}
