namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class OperationCanceledRemoteOperationResult : IRemoteOperationResult
	{
		public static readonly IRemoteOperationResult Instance = new OperationCanceledRemoteOperationResult();

		private OperationCanceledRemoteOperationResult()
		{
		}

		public int RtuId => -1;
	}
}
