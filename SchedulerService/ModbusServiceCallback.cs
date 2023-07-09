using SchedulerService.ModbusServiceReference;

namespace SchedulerService
{
	public sealed class ModbusServiceCallback : IModbusDuplexCallback
	{
		public void ReceiveCommandResult(CommandResultBase commandResult)
		{
			throw new System.NotImplementedException();
		}
	}
}