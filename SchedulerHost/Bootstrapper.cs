using Autofac;
using SchedulerLibrary;
using SchedulerLibrary.ModbusServiceReference;
using SchedulerLibrary.RtuConfiguration;
using System.ServiceModel;

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
			builder.RegisterType<SchedulerLibrary.ModelServiceReference.ModelServiceClient>().As<SchedulerLibrary.ModelServiceReference.IModelService>();
			builder.RegisterType<SchedulerRtuConfiguration>().As<ISchedulerRtuConfiguration>().OnActivated(r => r.Instance.InitializeData());
			builder.RegisterType<SchedulerService>().As<ISchedulerService>();
			return builder;
		}
	}
}
