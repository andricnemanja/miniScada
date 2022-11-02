﻿using System;
using System.Runtime.Serialization;

namespace ClientWpfApp.Circuit_Breaker
{
    [Serializable]
    internal class CircuitBreakerOpenException : Exception
    {
        public Exception LastException { get; set; }

        public CircuitBreakerOpenException(Exception lastException)
        {
            LastException = lastException;
        }
    }
}