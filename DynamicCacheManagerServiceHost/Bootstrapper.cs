using Autofac;
using DynamicCacheManager;
using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.DynamicCacheClient.RedisCacheClient;
using DynamicCacheManager.ResultsProcessing;
using DynamicCacheManager.ServiceCache;

namespace DynamicCacheManagerHost
{
	public class Bootstrapper
	{

		public static ContainerBuilder RegisterContainerBuilder()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<DynamicCacheManagerService>().As<IDynamicCacheManagerService>();
			builder.RegisterType<StaticDataLoader>().As<IStaticDataLoader>();
			builder.RegisterType<DynamicCacheManager.ModelServiceReference.ModelServiceClient>().As<DynamicCacheManager.ModelServiceReference.IModelService>();
			builder.RegisterType<RedisDynamicCacheClient>().As<IDynamicCacheClient>().SingleInstance();
			builder.RegisterType<ServiceRtuCache>().As<IServiceRtuCache>().OnActivated(c => c.Instance.InitializeData());
			builder.RegisterType<CommandResultQueue>().As<ICommandResultQueue>();
			builder.RegisterType<CommandResultReceiver>().As<ICommandResultReceiver>();
			builder.RegisterType<RedisStringBuilder>().As<ISignalNameStringBuilder>();

			return builder;
		}
	}
}
