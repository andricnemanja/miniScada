using ModelClient.ModelServiceReference;
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
            ModelServiceClient modelServiceClient = new ModelServiceClient();

            try
            {
                Console.WriteLine(modelServiceClient.GetRTU(5).Name);
            }
            catch(FaultException<ModelServiceException> ex)
            {
                int output = (int)ex.Detail.FaultCode;
				Console.WriteLine(output.ToString().PadLeft(4, '0'));
            }
            Console.ReadKey();

            modelServiceClient.Close();
        }
    }
}
