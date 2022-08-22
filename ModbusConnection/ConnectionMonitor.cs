using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NModbus;


namespace ModbusConnection
{
    public class ConnectionMonitor
    {
        public static bool IsAvailable(IModbusMaster master, string IpAddress)
        {
            try
            {
                TcpClient client = new TcpClient(IpAddress, 502);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
