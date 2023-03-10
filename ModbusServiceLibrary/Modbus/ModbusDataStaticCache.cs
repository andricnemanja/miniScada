using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.Modbus
{
	public class ModbusDataStaticCache : IModbusDataStaticCache
	{
		private readonly IModelService modelService;
		private readonly List<IAnalogPoint> analogPoints = new List<IAnalogPoint>();
		private readonly List<IDigitalPoint> digitalPoints = new List<IDigitalPoint>();

		public ModbusDataStaticCache(IModelService modelService)
		{
			this.modelService = modelService;
		}

		public void Initialize()
		{
			foreach (var rtu in modelService.GetAllRTUs())
			{
				foreach (var analogSignal in rtu.AnalogSignals)
				{
					if (analogSignal.AccessType == SignalAccessType.Output)
					{
						HoldingRegister newAnalogPoint = new HoldingRegister(0, analogSignal.ID, analogSignal.Address, analogSignal.MappingId, rtu.RTUData.ID);
						analogPoints.Add(newAnalogPoint);
					}
					else
					{
						AnalogInput newAnalogPoint = new AnalogInput(0, analogSignal.ID, analogSignal.Address, analogSignal.MappingId, rtu.RTUData.ID);
						analogPoints.Add(newAnalogPoint);
					}
				}

				foreach (var discreteSignal in rtu.DiscreteSignals)
				{
					if (discreteSignal.AccessType == SignalAccessType.Output)
					{
						Coil newDiscretePoint = new Coil(0, discreteSignal.ID, discreteSignal.Address, discreteSignal.MappingId, discreteSignal.SignalType == DiscreteSignalType.OneBit ? (byte)1 : (byte)2, rtu.RTUData.ID);
						digitalPoints.Add(newDiscretePoint);
					}
					else
					{
						DigitalInput newDiscretePoint = new DigitalInput(0, discreteSignal.ID, discreteSignal.Address, discreteSignal.MappingId, discreteSignal.SignalType == DiscreteSignalType.OneBit ? (byte)1 : (byte)2, rtu.RTUData.ID);
						digitalPoints.Add(newDiscretePoint);
					}
				}
			}
		}

		public RTU GetRTU(int rtuId)
		{
			return modelService.GetRTU(rtuId);
		}

		public IAnalogPoint FindAnalogPoint(int signalId)
		{
			return analogPoints.SingleOrDefault(s => s.SignalId == signalId);
		}

		public IDigitalPoint FindDiscretePoint(int signalId)
		{
			return digitalPoints.SingleOrDefault(s => s.SignalId == signalId);
		}
	}
}
