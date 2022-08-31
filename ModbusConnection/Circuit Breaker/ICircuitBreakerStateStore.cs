using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Circuit_Breaker
{
    internal interface ICircuitBreakerStateStore
    {
        CircuitBreakerStateEnum State { get; set; }

        public Exception LastException { get; set; }

        DateTime LastStateChangedDateUtc { get; set; }

        void Trip(Exception ex);

        void Reset();

        void HalfOpen();

        bool IsClosed { get; set; }
    }
}
