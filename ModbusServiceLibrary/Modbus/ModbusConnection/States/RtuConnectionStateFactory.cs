namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	/// <summary>
	/// Class <c>RtuConnectionFactory</c> creates IRtuConnectionState instances.
	/// </summary>
	public sealed class RtuConnectionStateFactory : IRtuConnectionStateFactory
	{
		/// <summary>
		/// Create <c>IRtuConnectionState</c> for RTU baseed on current connection state.
		/// </summary>
		/// <param name="rtuConnectionState">Current state of the connection.</param>
		/// <param name="rtuConnection">RtuConnection to which the connection state belongs.</param>
		/// <returns><see cref="IRtuConnectionState"/>New connection state.</returns>
		public IRtuConnectionState CreateConnection(RtuConnectionState rtuConnectionState, IRtuConnection rtuConnection)
		{
			switch (rtuConnectionState)
			{
				case RtuConnectionState.Connecting:
					return new ConnectingRtuState(rtuConnection);
				case RtuConnectionState.Online:
					return new OnlineRtuState(rtuConnection);
				default:
					return new DisconnectedRtuState(rtuConnection);
			}
		}
	}
}
