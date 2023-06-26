using Autofac;
using SchedulerService.RtuConfiguration;

namespace SchedulerService
{
	/// <summary>
	/// Definining dependencies for Scheduler Service classes
	/// </summary>
	public sealed class Bootstrapper
	{
		/// <summary>
		/// Create container that have all dependencies for Scheduler Service classes
		/// </summary>
		public static ContainerBuilder RegisterContainerBuilder()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<ModelServiceReference.ModelServiceClient>().As<ModelServiceReference.IModelService>();
			builder.RegisterType<SchedulerRtuConfiguration>().As<ISchedulerRtuConfiguration>().OnActivated(r => r.Instance.InitializeData());
			return builder;
		}
	}
}
