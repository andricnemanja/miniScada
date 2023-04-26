using System.ServiceModel;
using DynamicCacheManager.ModbusCallback;
using DynamicCacheManager.ModbusServiceReference;
using DynamicCacheManager.ResultsProcessing;
using DynamicCacheManager.ServiceCache;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public sealed class DynamicCacheManagerService : IDynamicCacheManagerService
	{
		private readonly IStaticDataLoader staticDataLoader;
		private readonly IServiceRtuCache serviceRtuCache;
		public DynamicCacheManagerService(IStaticDataLoader staticDataLoader, ICommandResultQueue commandResultQueue, IServiceRtuCache serviceRtuCache)
		{
			this.staticDataLoader = staticDataLoader;
			this.serviceRtuCache = serviceRtuCache;
			this.serviceRtuCache.RtuList = this.staticDataLoader.InitializeData();

			ModbusServiceCallback modbusServiceCallback = new ModbusServiceCallback(commandResultQueue);
			InstanceContext instanceContext = new InstanceContext(modbusServiceCallback);
			var modbusDuplexClient = new ModbusDuplexClient(instanceContext);
			modbusDuplexClient.Subscribe();
		}
		public void ProcessCommandResult(CommandResultBase commandResult)
		{
		}
	}
}
