using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model
{
    public class RTU
    {
        public RTUData Data { get; set; }
        public RTUValues Values { get; set; }
        public RTUConnection Connection { get; set; }

        public RTU(RTUData data, RTUValues values, RTUConnection connection)
        {
            Data = data;
            Values = values;
            Connection = connection;
        }
    }
}
