using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpfApp.Circuit_Breaker
{
    internal class CircuitBreakerStateStore : ICircuitBreakerStateStore
    {

        public CircuitBreakerStateEnum State { get; set; } = CircuitBreakerStateEnum.OPEN;

        public Exception LastException { get; set; } = new NotImplementedException();

        public DateTime LastStateChangedDateUtc { get; set; } = DateTime.UtcNow;

        public bool IsClosed { get; set; } = true;

        public void HalfOpen()
        {
            State = CircuitBreakerStateEnum.HALF_OPEN;
            LastStateChangedDateUtc = DateTime.UtcNow;
        }

        public void Reset()
        {
            State = CircuitBreakerStateEnum.OPEN;
            LastStateChangedDateUtc = DateTime.UtcNow;
            IsClosed = true;
        }

        public void Trip(Exception ex)
        {
            LastException = ex;
            LastStateChangedDateUtc = DateTime.UtcNow;
            State = CircuitBreakerStateEnum.CLOSED;
            IsClosed = false;

        }
    }
}
