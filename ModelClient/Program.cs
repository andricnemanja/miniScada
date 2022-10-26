using ModelClient.ModelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelServiceClient modelServiceClient = new ModelServiceClient();

            Console.WriteLine(modelServiceClient.GetRTU(1).Name);
            Console.ReadKey();

            modelServiceClient.Close();
        }
    }
}
