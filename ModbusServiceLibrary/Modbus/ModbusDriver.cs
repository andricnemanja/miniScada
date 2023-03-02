using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModelServiceReference;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.Modbus
{
	public class ModbusDriver : IProtocolDriver
	{
		private readonly ISignalMapper signalMapper;
		private readonly IModelService modelService;
		private readonly IModbusClient modbusClient;

		public ModbusDriver(ISignalMapper signalMapper, IModelService modelService, IModbusClient modbusClient)
		{
			this.signalMapper = signalMapper;
			this.modelService = modelService;
			this.modbusClient = modbusClient;
		}

		public List<IAnalogPoint> AnalogPoints { get; set; } = new List<IAnalogPoint>();
		public List<IDigitalPoint> DigitalPoints { get; set; } = new List<IDigitalPoint>();

		public void Initialize()
		{
			foreach (var rtu in modelService.GetAllRTUs())
			{
				foreach (var analogSignal in rtu.AnalogSignals)
				{
					if (analogSignal.AccessType == SignalAccessType.Output)
					{
						HoldingRegister newAnalogPoint = new HoldingRegister(0, analogSignal.ID, analogSignal.Address, analogSignal.MappingId, rtu.RTUData.ID);
						AnalogPoints.Add(newAnalogPoint);
					}
					else
					{
						AnalogInput newAnalogPoint = new AnalogInput(0, analogSignal.ID, analogSignal.Address, analogSignal.MappingId, rtu.RTUData.ID);
						AnalogPoints.Add(newAnalogPoint);
					}
				}

				foreach (var discreteSignal in rtu.DiscreteSignals)
				{
					if (discreteSignal.AccessType == SignalAccessType.Output)
					{
						Coil newDiscretePoint = new Coil(0, discreteSignal.ID, discreteSignal.Address, discreteSignal.MappingId, discreteSignal.SignalType == DiscreteSignalType.OneBit ? (byte)1 : (byte)2, rtu.RTUData.ID);
						DigitalPoints.Add(newDiscretePoint);
					}
					else
					{
						DigitalInput newDiscretePoint = new DigitalInput(0, discreteSignal.ID, discreteSignal.Address, discreteSignal.MappingId, discreteSignal.SignalType == DiscreteSignalType.OneBit ? (byte)1 : (byte)2, rtu.RTUData.ID);
						DigitalPoints.Add(newDiscretePoint);
					}
				}
			}
		}

		public string ReadDiscreteSignal(int signalId)
		{
			IDigitalPoint digitalPoint = FindDiscretePoint(signalId);
			byte rawValue = digitalPoint.Read(modbusClient);
			return signalMapper.ConvertDiscreteSignalValueToState(digitalPoint.MappingId, rawValue);

		}
		public double ReadAnalogSignal(int signalId)
		{
			IAnalogPoint analogPoint = FindAnalogPoint(signalId);
			ushort rawValue = analogPoint.Read(modbusClient);
			return signalMapper.ConvertAnalogSignalToRealValue(analogPoint.MappingId, rawValue);
		}

		public bool TryWriteAnalogSignal(int signalId, double newValue)
		{
			IAnalogPoint analogPoint = FindAnalogPoint(signalId);
			int rawValue = signalMapper.ConvertRealValueToAnalogSignalValue(analogPoint.MappingId, newValue);
			return analogPoint.TryWrite(modbusClient, rawValue);
		}
		public bool TryWriteDiscreteSignal(int signalId, string newState)
		{
			IDigitalPoint digitalPoint = FindDiscretePoint(signalId);
			byte rawValue = signalMapper.ConvertStateToDiscreteSignalValue(digitalPoint.MappingId, newState);
			return FindDiscretePoint(signalId).TryWrite(modbusClient, rawValue);
		}

		public bool TryConnectToRtu(int rtuId, string rtuAddress, int port)
		{
			return modbusClient.TryConnect(rtuId, rtuAddress, port);
		}

		private IAnalogPoint FindAnalogPoint(int signalId)
		{
			return AnalogPoints.SingleOrDefault(s => s.SignalId == signalId);
		}

		private IDigitalPoint FindDiscretePoint(int signalId)
		{
			return DigitalPoints.SingleOrDefault(s => s.SignalId == signalId);
		}
	}
}
