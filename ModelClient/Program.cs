using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
			InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
			ModbusServiceReference.ModbusDuplexClient modbusClient = new ModbusServiceReference.ModbusDuplexClient(instanceContext);

            modbusClient.ReadAnalogSignal(1, 1);


            Console.ReadKey();

			modbusClient.Close();
        }
    }
}
