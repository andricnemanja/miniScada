using Autofac;
using Scheduler;

namespace SchedulerHost
{
	/// <summary>
	/// Definining dependencies for Model Service classes
	/// </summary>
	public sealed class Bootstrapper
	{
		/// <summary>
		/// Create container that have all dependencies for Model Service classes
		/// </summary>
		public static ContainerBuilder RegisterContainerBuilder()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<SchedulerService>().As<ISchedulerService>();
			return builder;
		}
	}
}
