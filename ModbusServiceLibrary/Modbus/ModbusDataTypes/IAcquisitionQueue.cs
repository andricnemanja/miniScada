using System.Threading;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IAcquisitionQueue
	{
		void Enqueue(IRemoteOperationResult result);

		IRemoteOperationResult Dequeue(CancellationToken token);
	}
}