using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class AcquisitionQueue : IAcquisitionQueue
	{
		public static readonly AcquisitionQueue Instance = new AcquisitionQueue();
		private readonly BlockingCollection<IRemoteOperationResult> queue = new BlockingCollection<IRemoteOperationResult>();

		private AcquisitionQueue()
		{
		}

		public void Enqueue(IRemoteOperationResult result)
		{
			queue.Add(result);
		}

		public IRemoteOperationResult Dequeue(CancellationToken token)
		{
			try
			{
				return queue.Take(token);
			}
			catch (OperationCanceledException)
			{
				return OperationCanceledRemoteOperationResult.Instance;
			}
		}
	}
}
