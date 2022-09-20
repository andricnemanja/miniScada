using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model.Signals
{
    public interface ISignal
    {
        int Address { get; set; }
        string Name { get; set; }
    }
}
