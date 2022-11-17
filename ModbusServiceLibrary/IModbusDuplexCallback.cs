using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary
{
	public interface IModbusDuplexCallback
	{
		[OperationContract(IsOneWay = true)]
		void UpdateAnalogSignalValue(int rtuId, int signalAddress, int signalValue);
	}
}
