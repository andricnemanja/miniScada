namespace ModbusServiceLibrary.CommandResult
{
	public interface ICommandResult
	{
		int RtuId { get; set; }
		CommandStatus CommandStatus { get; set; }
	}
}
