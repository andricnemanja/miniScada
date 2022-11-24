using ModbusServiceLibrary.ContractTypes;
using ModbusServiceLibrary.Data;
using ModbusServiceLibrary.ServiceReader;
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
		private RtuStaticData rtuStaticData;

		public ModbusService(IModelServiceReader modelServiceReader)
		{
			Callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			rtuStaticData= new RtuStaticData(modelServiceReader);
			rtuStaticData.InitializeData();

		}

		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			
			int signalValue = 10;
			Callback.UpdateAnalogSignalValue(rtuId, signalAddress, signalValue);
		}

		public List<Model.RTU.RTUData> GetAllRtuData()
		{
			List<Model.RTU.RTUData> rtuData = new List<Model.RTU.RTUData>();
			foreach (var rtu in rtuStaticData.RtuList)
				rtuData.Add(rtu.RTUData);
			return rtuData;
		}
	}
}
