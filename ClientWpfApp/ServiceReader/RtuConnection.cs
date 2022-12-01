using ClientWpfApp.ModbusServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpfApp.ServiceReader
{
	public class RtuConnection
	{
		private readonly ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;

		public RtuConnection(ModbusDuplexClient modbusDuplexClient)
		{
			this.modbusDuplexClient = modbusDuplexClient;
		}

		public bool TryConnectToRtu(int rtuId)
		{
			return modbusDuplexClient.TryConnectToRtu(rtuId);
		}
	}
}
