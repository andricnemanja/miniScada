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

		public ModbusDriver(ISignalMapper signalMapper, IModbusClient modbusClient, IModbusDataStaticCache modbusDataStaticCache)
		{
			this.signalMapper = signalMapper;
			this.modbusClient = modbusClient;
			this.modbusDataStaticCache = modbusDataStaticCache;
		}
		public bool TryReadDiscreteSignal(int signalId, out string state)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			if(digitalPoint.TryRead(modbusClient, out byte rawValue))
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
			if(analogPoint.TryRead(modbusClient, out ushort rawValue))
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
			modbusClient.TryConnect(rtuId, rtuAddress, port);
			return true;
		}
	}
}
