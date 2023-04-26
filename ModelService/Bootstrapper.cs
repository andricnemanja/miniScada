using Autofac;
using ModelWcfServiceLibrary;
using ModelWcfServiceLibrary.FileAccessing;
using ModelWcfServiceLibrary.Model.Flags;
using ModelWcfServiceLibrary.Model.RTU;
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

			builder.RegisterType<JsonListSerializer<RTU>>().As<IListSerializer<RTU>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\RTUs.json"));
			builder.RegisterType<JsonListSerializer<AnalogSignalMapping>>().As<IListSerializer<AnalogSignalMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\AnalogSignalMappings.json"));
			builder.RegisterType<JsonListSerializer<DiscreteSignalMapping>>().As<IListSerializer<DiscreteSignalMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\DiscreteSignalMappings.json"));
			builder.RegisterType<JsonListSerializer<Flag>>().As<IListSerializer<Flag>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\Flags.json"));

			builder.RegisterType<AnalogSignalMappingRepository>().As<IAnalogSignalMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<DiscreteSignalMappingRepository>().As<IDiscreteSignalMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<RtuRepository>().As<IRtuRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<FlagRepository>().As<IFlagRepository>()
				.OnActivated(c => c.Instance.Deserialize());

			builder.RegisterType<ModelService>().As<IModelService>();

			return builder;
		}
	}
}   
