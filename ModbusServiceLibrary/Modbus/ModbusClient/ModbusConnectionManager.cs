using System.Collections.Generic;
using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.ModbusConnection;

namespace ModbusServiceLibrary.ModbusClient
{
	/// <summary>
	/// Class <c>ModbusConnectionManager</c> holds TCP connections for all RTUs.
	/// </summary>
	public sealed class ModbusConnectionManager : IModbusConnectionManager
	{
		private readonly Dictionary<int, RtuConnection> rtuConnectionById = new Dictionary<int, RtuConnection>();
		private readonly IDynamicCacheManagerService dynamicCacheManagerServiceClient;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusConnectionManager"/>.
		/// </summary>
		/// <param name="dynamicCacheManagerServiceClient">Instance of the <see cref="IDynamicCacheManagerService"/> class.</param>
		public ModbusConnectionManager(IDynamicCacheManagerService dynamicCacheManagerServiceClient)
		{
			this.dynamicCacheManagerServiceClient = dynamicCacheManagerServiceClient;
		}

		/// <summary>
		/// Get connection for RTU.
		/// </summary>
		/// <param name="rtuId">ID of the RTU for which connection is requested.</param>
		public RtuConnection GetRtuConnection(int rtuId)
		{
			if (rtuConnectionById.TryGetValue(rtuId, out RtuConnection connection))
			{
				return connection;
			}

			RtuConnection newConnection = new RtuConnection(rtuId, dynamicCacheManagerServiceClient);
			rtuConnectionById.Add(rtuId, newConnection);
			return newConnection;
		}
	}
}