using Autofac;
using ModbusServiceLibrary;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

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
			builder.RegisterType<ModelServiceReader>().As<IModelServiceReader>()
				.OnActivated(c => c.Instance.InitializeData()).SingleInstance();
			builder.RegisterType<ModbusService>().As<IModbusDuplex>();
			builder.RegisterType<ModbusSimulatorClient>().As<IModbusSimulatorClient>();
			builder.RegisterType<ModbusCommandInvoker>().As<IModbusCommandInvoker>();
			builder.RegisterType<RtuCommandInvoker>().As<IRtuCommandInvoker>();
			builder.RegisterType<CommandReceiver>().As<ICommandReceiver>();
			builder.RegisterType<NModbusClient2>().As<IModbusClient2>();
			builder.RegisterType<ValueConverter>().As<IValueConverter>()
				.OnActivated(c => c.Instance.Initialize()); ;
			builder.RegisterType<SignalMapper>().As<ISignalMapper>();

			return builder;
		}
	}
}
