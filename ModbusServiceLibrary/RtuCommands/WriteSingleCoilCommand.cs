using ModbusServiceLibrary.Model.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.RtuCommands
{
	public class WriteSingleCoilCommand : IRtuCommand
	{
		public int RtuId { get; }
		public int SignalId { get; }
		public string State { get; }

		public WriteSingleCoilCommand(int rtuId, int signalId, string state)
		{
			RtuId = rtuId;
			SignalId = signalId;
			State = state;
		}
	}
}
