using ModbusConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.ViewModel
{
    internal class MainViewModel
    {
        public List<RTU> RTUList { get; set; } = new List<RTU>
        {
            new RTU(new RTUData("Uredjaj 1", "127.0.0.1", 502), new RTUValues(), new RTUConnection(null)),
            new RTU(new RTUData("Uredjaj 2", "127.0.0.1", 503), new RTUValues(), new RTUConnection(null)),
            new RTU(new RTUData("Uredjaj 3", "127.0.0.1", 504), new RTUValues(), new RTUConnection(null))
        };


        


    }
}
