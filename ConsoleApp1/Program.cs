using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		[ServiceContract]
		public interface IOperations
		{
			[OperationContract]
			void DoWork();
		}


		static void Main(string[] args)
		{
			WSDualHttpBinding binding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
			EndpointAddress address = new EndpointAddress(new Uri("http://127.0.0.1:8090"));
			var channel = ChannelFactory<IOperations>.CreateChannel(binding, address);

			Console.WriteLine("Channel opened...");

			channel.DoWork();
		
		}
	}
}
