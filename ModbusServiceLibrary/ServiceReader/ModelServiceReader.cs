using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ServiceReader
{
	public class ModelServiceReader : IModelServiceReader
	{
		private readonly ModelServiceReference.IModelService modelService;

		public ModelServiceReader(ModelServiceReference.IModelService modelService)
		{
			this.modelService = modelService;
		}

		public List<RTU> ReadAllRTUs()
		{
			List<RTU> rtus = new List<RTU>();

			foreach (var rtu in modelService.GetRTUsEssentialData())
			{
				IModbusClient modbusClient = new NModbusClient(rtu.IpAddress, rtu.Port);
				RTU newRTU = new RTU()
				{
					RTUData = new RTUData()
					{
						ID = rtu.ID,
						IpAddress = rtu.IpAddress,
						Name = rtu.Name,
						Port = rtu.Port
					},
					Connection = new RTUConnection(null),
					AnalogSignalValues = GetAnalogSignalValuesForRTU(rtu.ID),
					DiscreteSignalValues = GetDiscreteSignalValuesForRTU(rtu.ID)
				};
				rtus.Add(newRTU);
			}

			return rtus;
		}

		private List<AnalogSignalValue> GetAnalogSignalValuesForRTU(int rtuID)
		{
			List<AnalogSignalValue> analogSignalValues = new List<AnalogSignalValue>();

			foreach (var analogSignal in modelService.GetAnalogSignalsForRtu(rtuID))
			{
				analogSignalValues.Add(new AnalogSignalValue()
				{
					AnalogSignal = new AnalogSignal
					{
						Address = analogSignal.Address,
						ID = analogSignal.ID,
						Name = analogSignal.Name
					},
					Value = 0
				});
			}

			return analogSignalValues;
		}

		private List<DiscreteSignalValue> GetDiscreteSignalValuesForRTU(int rtuID)
		{
			List<DiscreteSignalValue> discreteSignalValues = new List<DiscreteSignalValue>();

			foreach (var discreteSignal in modelService.GetDiscreteSignalsForRtu(rtuID))
			{
				discreteSignalValues.Add(new DiscreteSignalValue()
				{
					DiscreteSignal = new DiscreteSignal
					{
						Address = discreteSignal.Address,
						ID = discreteSignal.ID,
						Name = discreteSignal.Name
					},
					Value = false
				});
			}

			return discreteSignalValues;
		}
	}
}
