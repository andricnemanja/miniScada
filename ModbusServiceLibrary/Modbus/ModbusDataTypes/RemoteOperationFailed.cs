namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class RemoteOperationFailed : IRemoteOperationResult
	{
		public int RtuId { get; }
	}
}
