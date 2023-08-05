using Autofac;
using ModbusServiceLibrary;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
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
			builder.RegisterType<ModbusRtuConfiguration>().As<IModbusRtuConfiguration>()
				.OnActivated(c => c.Instance.InitializeData()).SingleInstance();
			builder.RegisterType<ModbusService>().As<IModbusService>();
			builder.RegisterType<RtuCommandInvoker>().As<IRtuCommandInvoker>();
			builder.RegisterType<CommandReceiver>().As<ICommandReceiver>();
			builder.RegisterType<NModbusClient>().As<IModbusClient>()
				.SingleInstance();
			builder.RegisterType<ModbusConnectionManager>().As<IModbusConnectionManager>();
			builder.RegisterType<SignalMapper>().As<ISignalMapper>();
			builder.RegisterType<ModbusDriver>().As<IProtocolDriver>();
			builder.RegisterType<ModbusDataStaticCache>().As<IModbusDataStaticCache>()
				.OnActivated(c => c.Instance.Initialize());
			builder.RegisterType<ModbusServiceLibrary.DynamicCacheManagerReference.DynamicCacheManagerServiceClient>().As<ModbusServiceLibrary.DynamicCacheManagerReference.IDynamicCacheManagerService>().SingleInstance();
			builder.RegisterType<RtuConnectionStateFactory>().As<IRtuConnectionStateFactory>();
			builder.RegisterType<RtuConnectionFactory>().As<IRtuConnectionFactory>();
			return builder;
		}
	}
}
