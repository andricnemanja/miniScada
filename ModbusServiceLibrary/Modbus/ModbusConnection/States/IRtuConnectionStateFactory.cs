namespace ModbusServiceLibrary.Modbus.ModbusConnection.States
{
	/// <summary>
	/// <c>IRtuConnectionFactory</c> creates IRtuConnectionState instances.
	/// </summary>
	public interface IRtuConnectionStateFactory
	{
		/// <summary>
		/// Create <c>IRtuConnectionState</c> for RTU baseed on current connection state.
		/// </summary>
		/// <param name="rtuConnectionState">Current state of the connection.</param>
		/// <param name="rtuConnection">RtuConnection to which the connection state belongs.</param>
		/// <returns><see cref="IRtuConnectionState"/>New connection state.</returns>
		IRtuConnectionState CreateConnection(RtuConnectionState rtuConnectionState, IRtuConnection rtuConnection);
	}
}