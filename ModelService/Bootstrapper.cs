using Autofac;
using ModelWcfServiceLibrary;
using ModelWcfServiceLibrary.FileAccessing;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using ModelWcfServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Repository;
using ModelWcfServiceLibrary.Serializer;

namespace ModelServiceHost
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

			builder.RegisterType<FileAccess>().As<IFileAccess>();

			builder.RegisterType<JsonListSerializer<ModelRTU>>().As<IListSerializer<ModelRTU>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\RTUs.json"));
			builder.RegisterType<JsonListSerializer<ModelAnalogSignalMapping>>().As<IListSerializer<ModelAnalogSignalMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\AnalogSignalMappings.json"));
			builder.RegisterType<JsonListSerializer<ModelDiscreteSignalMapping>>().As<IListSerializer<ModelDiscreteSignalMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\DiscreteSignalMappings.json"));
			builder.RegisterType<JsonListSerializer<SignalScanPeriodMapping>>().As<IListSerializer<SignalScanPeriodMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\ScanPeriodMappings.json"));

			builder.RegisterType<AnalogSignalMappingRepository>().As<IAnalogSignalMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<DiscreteSignalMappingRepository>().As<IDiscreteSignalMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<RtuRepository>().As<IRtuRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<SignalScanPeriodMappingRepository>().As<ISignalScanPeriodMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());

			builder.RegisterType<ModelService>().As<IModelService>();

			return builder;
		}
	}
}   
