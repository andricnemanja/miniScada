using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
	[ServiceContract]
	public interface ISchedulerCallback
	{
		[OperationContract(IsOneWay = true)]
		void ReceiveCommandResult();
	}
}
