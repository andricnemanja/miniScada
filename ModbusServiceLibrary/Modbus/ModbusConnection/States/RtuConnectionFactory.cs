using ModbusServiceLibrary.ModbusConnection;
using ModbusServiceLibrary.ModbusConnection.States;

namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	public sealed class RtuConnectionStateFactory : IRtuConnectionStateFactory
	{
		public IRtuConnectionState CreateConnection(RtuConnectionState rtuConnectionState, RtuConnection rtuConnection)
		{
			switch (rtuConnectionState)
			{
				case RtuConnectionState.Connecting:
					return new ConnectingRtuState(rtuConnection);
				case RtuConnectionState.Online:
					return new ConnectedRtuState(rtuConnection);
				default:
					return new DisconnectedRtuState(rtuConnection);
			}
		}
	}
}
