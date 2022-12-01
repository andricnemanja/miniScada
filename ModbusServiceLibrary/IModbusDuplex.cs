using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary
{
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IModbusDuplexCallback))]
	public interface IModbusDuplex
	{
		[OperationContract(IsOneWay = true)]
		void ReadAnalogSignal(int rtuId, int signalAddress);
		[OperationContract(IsOneWay = true)]
		void ReadDiscreteSignal(int rtuId, int signalAddress);
		[OperationContract(IsOneWay = true)]
		void WriteAnalogSignal(int rtuId, int signalAddress, int newValue);
		[OperationContract(IsOneWay = true)]
		void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue);
		[OperationContract(IsOneWay = false)]
		bool TryConnectToRtu(int rtuId);
	}
}
