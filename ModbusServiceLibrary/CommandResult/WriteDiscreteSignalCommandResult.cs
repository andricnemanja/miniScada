using System.Runtime.Serialization;

namespace ModbusServiceLibrary.CommandResult
{
	[DataContract]
	public class WriteDiscreteSignalCommandResult : CommandResultBase
	{
		public WriteDiscreteSignalCommandResult(int rtuId) : base(rtuId)
		{
		}

	}
}
