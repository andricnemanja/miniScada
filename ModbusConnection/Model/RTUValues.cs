using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model
{
    internal class RTUValues
    {
        public int Register1 { get; set; }
        public int Register2 { get; set; }
        public bool Coil1 { get; set; }
        public bool Coil2 { get; set; }

        public RTUValues(int register1 = 0, int register2 = 0, bool coil1 = false, bool coil2 = false)
        {
            Register1 = register1;
            Register2 = register2;
            Coil1 = coil1;
            Coil2 = coil2;
        }
    }
}
