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
		public string ReadDiscreteSignal(int signalId)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			byte rawValue = digitalPoint.Read(modbusClient);
			return signalMapper.ConvertDiscreteSignalValueToState(digitalPoint.MappingId, rawValue);
		}
		public double ReadAnalogSignal(int signalId)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);
			ushort rawValue = analogPoint.Read(modbusClient);
			return signalMapper.ConvertAnalogSignalToRealValue(analogPoint.MappingId, rawValue);
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
	}
}
