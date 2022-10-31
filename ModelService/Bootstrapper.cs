using Autofac;
using ModelWcfServiceLibrary;
using ModelWcfServiceLibrary.FileAccessing;
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
			builder.RegisterType<JsonRtuSerializer>().As<IRtuSerializer>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\RTUs.json"));
			builder.RegisterType<RtuRepository>().As<IRtuRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<ModelService>().As<IModelService>();

			return builder;
		}
	}
}   
