using System.Collections.Generic;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class AnalogInputResult : IRemoteOperationResult
	{
		public AnalogInputResult(int rtuId)
		{
			RtuId = rtuId;
		}

		public int RtuId { get; }

		public Dictionary<int, ushort> Values { get; } = new Dictionary<int, ushort>();
	}
}
