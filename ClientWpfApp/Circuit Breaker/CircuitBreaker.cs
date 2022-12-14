using System;
using System.Threading;
using ClientWpfApp.ModbusClients;

namespace ClientWpfApp.Circuit_Breaker
{
	internal class CircuitBreaker
	{
		private readonly ICircuitBreakerStateStore stateStore = new CircuitBreakerStateStore();

		private readonly object halfOpenSyncObject = new object();

		private int OpenToHalfOpenWaitTime = 5;

		public bool IsClosed { get { return stateStore.IsClosed; } }

		public bool IsOpen { get { return !IsClosed; } }

		public int RecconectingTime { get { return 60 + (stateStore.LastStateChangedDateUtc.AddSeconds(OpenToHalfOpenWaitTime) - DateTime.Now).Seconds; } }

		private IModbusClient modbusClient;


		public CircuitBreaker(IModbusClient modbusClient)
		{
			this.modbusClient = modbusClient;
		}


		public void ExecuteAction(Action action)
		{
			if (IsOpen)
			{
				if (stateStore.LastStateChangedDateUtc.AddSeconds(OpenToHalfOpenWaitTime) < DateTime.UtcNow)
				{
					bool lockTaken = false;
					try
					{
						Monitor.TryEnter(halfOpenSyncObject, ref lockTaken);
						if (lockTaken)
						{
							stateStore.HalfOpen();

							modbusClient.Reconnect();
							action();

							OpenToHalfOpenWaitTime = 5;
							this.stateStore.Reset();
							return;
						}
					}
					catch (Exception ex)
					{
						OpenToHalfOpenWaitTime += (OpenToHalfOpenWaitTime < 60) ? 10 : 0;
						this.stateStore.Trip(ex);
						throw;
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(halfOpenSyncObject);
						}
					}
				}
				throw new CircuitBreakerOpenException(stateStore.LastException);
			}


			try
			{
				action();
			}
			catch (Exception ex)
			{
				TrackException(ex);
				throw;
			}
		}


		private void TrackException(Exception ex)
		{
			this.stateStore.Trip(ex);
		}



	}
}
