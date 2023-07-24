using System.Collections.Generic;
using ModbusServiceLibrary.ModbusConnection;

namespace ModbusServiceLibrary.ModbusClient
{
	public sealed class ModbusConnectionManager : IModbusConnectionManager
	{
		private readonly Dictionary<int, RtuConnection> rtuConnectionById = new Dictionary<int, RtuConnection>();

		public RtuConnection GetRtuConnection(int rtuId)
		{
			if (rtuConnectionById.TryGetValue(rtuId, out RtuConnection connection))
			{
				return connection;
			}

			RtuConnection newConnection = new RtuConnection();
			rtuConnectionById.Add(rtuId, newConnection);
			return newConnection;
		}
	}
}