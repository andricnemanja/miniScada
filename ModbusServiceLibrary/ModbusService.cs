using ModbusServiceLibrary.Data;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.ServiceReader;
using System;
using System.Collections.Generic;
using System.ServiceModel;


namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class ModbusService : IModbusDuplex
	{
		public IModbusDuplexCallback Callback { get; set; }
		private RtuDataList rtuStaticData;
		private IModbusWriter modbusWriter;

		public ModbusService(IModelServiceReader modelServiceReader, IModbusWriter modbusWriter)
		{
			Callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			rtuStaticData= new RtuDataList(modelServiceReader);
			rtuStaticData.InitializeData();
			this.modbusWriter = modbusWriter;
		}


		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			int signalValue = 10;
			
			Callback.UpdateAnalogSignalValue(rtuId, signalAddress, signalValue);
		}

		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			Callback.UpdateDiscreteSignalValue(rtuId, signalAddress, true);
		}

		public void WriteAnalogSignal(int rtuId, int signalAddress, int newValue)
		{
			modbusWriter.WriteAnalogSignalValue(rtuId, signalAddress, newValue);
		}

		public void WriteDiscreteSignal(int rtuId, int signalAddress, bool newValue)
		{
			modbusWriter.WriteDiscreteSignalValue(rtuId, signalAddress, newValue);
		}
	}
}
