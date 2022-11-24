using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient
{
	public class CallbackHandler : ModbusServiceReference.IModbusDuplexCallback
	{
		public void UpdateAnalogSignalValue(int rtuId, int signalAddress, int signalValue)
		{
			Console.WriteLine("Read analog signal");
		}
	}
}
