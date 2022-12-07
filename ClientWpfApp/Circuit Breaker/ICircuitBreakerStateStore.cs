using System;

namespace ClientWpfApp.Circuit_Breaker
{
	internal interface ICircuitBreakerStateStore
	{
		CircuitBreakerStateEnum State { get; set; }

		Exception LastException { get; set; }

		DateTime LastStateChangedDateUtc { get; set; }

		void Trip(Exception ex);

		void Reset();

		void HalfOpen();

		bool IsClosed { get; set; }
	}
}
