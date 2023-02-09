using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class WriteSingleCoilResult : ICommandResult
	{
		[DataMember]
		public CommandStatus CommandStatus { get; set; }

		[DataMember]
		public int RtuId { get; set; }	

		public WriteSingleCoilResult(CommandStatus commandStatus)
		{
			CommandStatus = commandStatus;
		}

	}
}
