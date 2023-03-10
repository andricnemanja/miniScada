using System;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.Modbus
{
	public sealed class RemotePoints
	{
		private readonly int rtuId;

		public RemotePoints(int rtuId, IModbusClient modbusClient)
		{
			this.rtuId = rtuId;
			HoldingRegisters = new AnalogInputRange(rtuId, modbusClient.TryReadHoldingRegisters);
			InputRegisters = new AnalogInputRange(rtuId, modbusClient.TryReadInputRegisters);
		}

		public AnalogInputRange HoldingRegisters { get; }

		public AnalogInputRange InputRegisters { get; }

		public void AddAnalogSignal(AnalogSignal analogSignal)
		{
			switch (analogSignal.AccessType)
			{
				case SignalAccessType.Input:
					InputRegisters.AddInput(new InputRegister2(rtuId, analogSignal.Address));
					break;
				case SignalAccessType.Output:
					InputRegisters.AddInput(new HoldingRegister2(rtuId, analogSignal.Address));
					break;
				default:
					throw new InvalidOperationException();
			}
		}
	}
}
