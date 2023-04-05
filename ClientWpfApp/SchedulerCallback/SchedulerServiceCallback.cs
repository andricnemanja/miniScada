using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpfApp.SchedulerCallback
{
	[CallbackBehavior(UseSynchronizationContext = false)]
	public sealed class SchedulerServiceCallback  //???
	{
		public void RecieveCommandResults()
		{

		}
	}
}
