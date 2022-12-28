using Autofac;
using ModbusServiceLibrary;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.SignalMapping;
using ModbusServiceLibrary.Repository;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;
using ModelWcfServiceLibrary.Serializer;

namespace ModbusServiceHost
{
	/// <summary>
	/// Definining dependencies for Modbus Service classes.
	/// </summary>
	public sealed class Bootstrapper
	{
		/// <summary>
		/// Create container that have all dependencies for Modbus Service classes.
		/// </summary>
		public static ContainerBuilder RegisterContainerBuilder()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<ModbusServiceLibrary.ModelServiceReference.ModelServiceClient>().As<ModbusServiceLibrary.ModelServiceReference.IModelService>();
			builder.RegisterType<ModelServiceReader>().As<IModelServiceReader>();
			builder.RegisterType<ModbusService>().As<IModbusDuplex>();
			builder.RegisterType<ModbusSimulatorClient>().As<IModbusSimulatorClient>()
				.OnActivated(c => c.Instance.InitializeData()).SingleInstance();
			builder.RegisterType<ModbusCommandInvoker>().As<IModbusCommandInvoker>();

			builder.RegisterType<JsonListSerializer<SignalMapping>>().As<IListSerializer<SignalMapping>>()
				.WithParameter(new TypedParameter(typeof(string), @"\Resources\SignalMappings.json"));
			builder.RegisterType<SignalMappingRepository>().As<ISignalMappingRepository>()
				.OnActivated(c => c.Instance.Deserialize());
			builder.RegisterType<ValueConverter>().As<IValueConverter>();

			return builder;
		}
	}
}
