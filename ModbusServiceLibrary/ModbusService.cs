using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class ModbusService : IModbusDuplex
	{
		public IModbusDuplexCallback Callback { get; set; }

		public ModbusService()
		{
			Callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
		}

		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			
			int signalValue = 10;


			Thread.Sleep(5000);

			Callback.UpdateAnalogSignalValue(rtuId, signalAddress, signalValue);
		}
	}
}
