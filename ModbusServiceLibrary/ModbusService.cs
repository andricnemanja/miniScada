using System.ServiceModel;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
	public sealed class ModbusService : IModbusService
	{
		private readonly ICommandReceiver commandReceiver;
		private readonly DynamicCacheManagerReference.IDynamicCacheManagerService dynamicCacheService;
		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusService"/>
		/// </summary>
		/// <param name="commandReceiver">Instance of the <see cref="ICommandReceiver"/> class</param>
		/// <param name="dynamicCacheManagerService">Instance of the <see cref="DynamicCacheManagerReference.IDynamicCacheManagerService"/> class</param>
		public ModbusService(ICommandReceiver commandReceiver, DynamicCacheManagerReference.IDynamicCacheManagerService dynamicCacheManagerService)
		{
			this.commandReceiver = commandReceiver;
			this.dynamicCacheService = dynamicCacheManagerService;
		}

		/// <summary>
		/// Method that recieves command sent from the Scheduler library.
		/// </summary>
		/// <param name="command">Commmand sent from Scheduler service.</param>
		public void ReceiveCommand(RtuCommandBase command)
		{
			var result = commandReceiver.ReceiveCommand(command);
			dynamicCacheService.ProcessCommandResult(result);
		}
	}
}
