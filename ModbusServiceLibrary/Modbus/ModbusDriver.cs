using System.Threading;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.Modbus
{
	public class ModbusDriver : IProtocolDriver
	{
		private readonly ISignalMapper signalMapper;
		private readonly IModbusClient modbusClient;
		private readonly IModbusDataStaticCache modbusDataStaticCache;
		private readonly AnalogInputFactory factory;

		public ModbusDriver(ISignalMapper signalMapper, IModbusClient modbusClient, IModbusDataStaticCache modbusDataStaticCache)
		{
			this.signalMapper = signalMapper;
			this.modbusClient = modbusClient;
			this.modbusDataStaticCache = modbusDataStaticCache;
			factory = new AnalogInputFactory(modbusDataStaticCache, modbusClient);
		}
		public bool TryReadDiscreteSignal(int signalId, out string state)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			if (digitalPoint.TryRead(modbusClient, out byte rawValue))
			{
				state = signalMapper.ConvertDiscreteSignalValueToState(digitalPoint.MappingId, rawValue);
				return true;
			}
			state = string.Empty;
			return false;
		}
		public bool TryReadAnalogSignal(int signalId, out double signalValue)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);
			if (analogPoint.TryRead(modbusClient, out ushort rawValue))
			{
				signalValue = signalMapper.ConvertAnalogSignalToRealValue(analogPoint.MappingId, rawValue);
				return true;
			}
			signalValue = 0;
			return false;
		}
		public bool TryWriteAnalogSignal(int signalId, double newValue)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);
			int rawValue = signalMapper.ConvertRealValueToAnalogSignalValue(analogPoint.MappingId, newValue);
			return analogPoint.TryWrite(modbusClient, rawValue);
		}
		public bool TryWriteDiscreteSignal(int signalId, string newState)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			byte rawValue = signalMapper.ConvertStateToDiscreteSignalValue(digitalPoint.MappingId, newState);
			return digitalPoint.TryWrite(modbusClient, rawValue);
		}
		public bool TryConnectToRtu(int rtuId, string rtuAddress, int port)
		{
			return modbusClient.TryConnect(rtuId, rtuAddress, port);
		}

		public void TryReadRtu(int rtuId)
		{
			RemotePoints points = factory.ReadRemotePoints(rtuId);
			//points.Coils.ReadRange();
			//points.DigitalInputs.ReadRange();
			points.HoldingRegisters.ReadRage();
			points.InputRegisters.ReadRage();
		}

		public void TryReadAnalogSignal(int signalId)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);
			AnalogInputReadOperation operation = (int rtuId, int startAddress, int numberOfPoints, out ushort[] values) => { values = null; return false; };

			IAnalogInput input = null;
			if (analogPoint is HoldingRegister)
			{
				operation = modbusClient.TryReadHoldingRegisters;
				input = new HoldingRegister2(analogPoint.RtuId, analogPoint.Address);
			}

			if (analogPoint is AnalogInput)
			{
				operation = modbusClient.TryReadInputRegisters;
				input = new InputRegister2(analogPoint.RtuId, analogPoint.Address);
			}

			AnalogInputRange range = new AnalogInputRange(analogPoint.RtuId, operation);
			range.AddInput(input);
			range.ReadRage();
		}

		public bool TryReadAnalogSignal2(int signalId, out double signalValue)
		{
			TryReadAnalogSignal(signalId);

			IRemoteOperationResult result = AcquisitionQueue.Instance.Dequeue(CancellationToken.None);
			AnalogInputResult analogInputResult = result as AnalogInputResult;

			if (analogInputResult == null)
			{
				signalValue = 0;
				return false;
			}

			signalValue = analogInputResult.Values[0];
			return true;
		}
	}
}
