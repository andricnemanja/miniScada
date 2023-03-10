using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.Modbus
{
	public sealed class AnalogInputFactory
	{
		private readonly IModbusDataStaticCache modbusDataStaticCache;
		private readonly IModbusClient modbusClient;

		public AnalogInputFactory(IModbusDataStaticCache modbusDataStaticCache, IModbusClient modbusClient)
		{
			this.modbusDataStaticCache = modbusDataStaticCache;
			this.modbusClient = modbusClient;
		}

		public RemotePoints ReadRemotePoints(int rtuId)
		{
			RemotePoints retVal = new RemotePoints(rtuId, modbusClient);
			RTU rtu = modbusDataStaticCache.GetRTU(rtuId);
			foreach (var item in rtu.AnalogSignals)
			{
				retVal.AddAnalogSignal(item);
			}

			return retVal;
		}
	}
}
