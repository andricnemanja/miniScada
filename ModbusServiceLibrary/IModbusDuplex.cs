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
		[OperationContract]
		void ReadAnalogSignal(int rtuId, int signalAddress);

		[OperationContract]
		List<Model.RTU.RTUData> GetAllRtuData();
	}
}
