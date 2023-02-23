using System.Runtime.Serialization;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class CommandProcessorNotFoundResult : CommandResultBase
	{
		public CommandProcessorNotFoundResult(IRtuCommand rtuCommand) 
		{
			RtuCommand = rtuCommand;
		}
		[DataMember]
		public IRtuCommand RtuCommand { get; set; }
	}
}
