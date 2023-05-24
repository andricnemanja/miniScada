using System.Runtime.Serialization;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class CommandProcessorNotFoundResult : CommandResultBase
	{
		public CommandProcessorNotFoundResult(RtuCommandBase rtuCommand) 
		{
			RtuCommand = rtuCommand;
		}
		[DataMember]
		public RtuCommandBase RtuCommand { get; set; }
	}
}
