using ModbusServiceLibrary.CommandResult;
using SchedulerLibrary.ModbusServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
	[CallbackBehavior(UseSynchronizationContext = false)]
	public class Callback : IModbusDuplexCallback
	{
		public void ReceiveCommandResult(CommandResultBase commandResult)
		{
			throw new NotImplementedException();
		}
	}
}
