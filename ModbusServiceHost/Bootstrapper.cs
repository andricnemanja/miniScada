using Autofac;
using ModbusServiceLibrary;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceHost
{
	/// <summary>
	/// Definining dependencies for Modbus Service classes
	/// </summary>
	public sealed class Bootstrapper
	{
		/// <summary>
		/// Create container that have all dependencies for Modbus Service classes
		/// </summary>
		public static ContainerBuilder RegisterContainerBuilder()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<ModbusServiceLibrary.ModelServiceReference.ModelServiceClient>().As<ModbusServiceLibrary.ModelServiceReference.IModelService>();
			builder.RegisterType<ModelServiceReader>().As<IModelServiceReader>();
			builder.RegisterType<ModbusService>().As<IModbusDuplex>();
			builder.RegisterType<ModbusConnection>().As<IModbusConnection>()
				.OnActivated(c => c.Instance.InitializeData()).SingleInstance();
			builder.RegisterType<ModbusCommandInvoker>().As<IModbusCommandInvoker>();

			return builder;
		}
	}
}   
