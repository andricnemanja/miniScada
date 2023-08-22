using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
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
		public RtuConnectionResponse ReadDiscreteSignal(int signalId, out string state)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			var commandResponse = digitalPoint.Read(modbusClient, out byte rawValue);
			if(commandResponse == RtuConnectionResponse.CommandExecuted)
			{
				state = signalMapper.ConvertDiscreteSignalValueToState(digitalPoint.MappingId, rawValue);
			}
			else
			{
				state = string.Empty;
			}
			return commandResponse;
		}
		public RtuConnectionResponse ReadAnalogSignal(int signalId, out double signalValue)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);

			var commandResponse = analogPoint.Read(modbusClient, out ushort rawValue);
			if(commandResponse == RtuConnectionResponse.CommandExecuted)
			{
				signalValue = signalMapper.ConvertAnalogSignalToRealValue(analogPoint.MappingId, rawValue);
			}
			else
			{
				signalValue = 0;
			}
			return commandResponse;
		}
		public RtuConnectionResponse WriteAnalogSignal(int signalId, double newValue)
		{
			IAnalogPoint analogPoint = modbusDataStaticCache.FindAnalogPoint(signalId);
			int rawValue = signalMapper.ConvertRealValueToAnalogSignalValue(analogPoint.MappingId, newValue);
			return analogPoint.Write(modbusClient, rawValue);
		}
		public RtuConnectionResponse WriteDiscreteSignal(int signalId, string newState)
		{
			IDigitalPoint digitalPoint = modbusDataStaticCache.FindDiscretePoint(signalId);
			byte rawValue = signalMapper.ConvertStateToDiscreteSignalValue(digitalPoint.MappingId, newState);
			return digitalPoint.Write(modbusClient, rawValue);
		}
		public RtuConnectionResponse ConnectToRtu(int rtuId, string rtuAddress, int port)
		{
			return modbusClient.Connect(rtuId, rtuAddress, port);
		}

		public RtuConnectionResponse DisconnectFromRtu(int rtuId)
		{
			return modbusClient.Disconnect(rtuId);
		}
	}
}
