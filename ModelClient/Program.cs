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
<<<<<<< HEAD
            ModelServiceClient modelServiceClient = new ModelServiceClient();           //proxy klasa
            modelServiceClient.Open();
=======
            ModelServiceClient modelServiceClient = new ModelServiceClient();
>>>>>>> 9e27fb551f1a77e880ea5e13e8455ad8bb04d5e8

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
