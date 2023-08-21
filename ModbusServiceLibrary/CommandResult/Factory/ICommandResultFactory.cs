using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.CommandResult.Factory
{
	public interface ICommandResultFactory
	{
		CommandResultBase CreateCommandResult(RtuConnectionResponse rtuConnectionResponse);
	}
}
