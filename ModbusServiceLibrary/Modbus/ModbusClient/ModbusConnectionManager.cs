using System.Collections.Concurrent;
using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;

namespace ModbusServiceLibrary.Modbus.ModbusClient
{
	/// <summary>
	/// Class <c>ModbusConnectionManager</c> holds TCP connections for all RTUs.
	/// </summary>
	public sealed class ModbusConnectionManager : IModbusConnectionManager
	{
		private readonly ConcurrentDictionary<int, IRtuConnection> rtuConnectionById = new ConcurrentDictionary<int, IRtuConnection>();
		private readonly IDynamicCacheManagerService dynamicCacheManagerServiceClient;
		private readonly IRtuConnectionStateFactory rtuConnectionStateFactory;
		private readonly IRtuConnectionFactory rtuConnectionFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusConnectionManager"/>.
		/// </summary>
		/// <param name="dynamicCacheManagerServiceClient">Instance of the <see cref="IDynamicCacheManagerService"/> class.</param>
		public ModbusConnectionManager(IDynamicCacheManagerService dynamicCacheManagerServiceClient, IRtuConnectionStateFactory rtuConnectionStateFactory, IRtuConnectionFactory rtuConnectionFactory)
		{
			this.dynamicCacheManagerServiceClient = dynamicCacheManagerServiceClient;
			this.rtuConnectionStateFactory = rtuConnectionStateFactory;
			this.rtuConnectionFactory = rtuConnectionFactory;
		}

		/// <summary>
		/// Get connection for RTU.
		/// </summary>
		/// <param name="rtuId">ID of the RTU for which connection is requested.</param>
		public IRtuConnection GetRtuConnection(int rtuId)
		{
			//GetOrAdd can run factory method multiple times but only first return value will be saved.
			return rtuConnectionById.GetOrAdd(rtuId, key =>
			{
				return rtuConnectionFactory.GetRtuConnection(key, dynamicCacheManagerServiceClient, rtuConnectionStateFactory);
			});
		}
	}
}