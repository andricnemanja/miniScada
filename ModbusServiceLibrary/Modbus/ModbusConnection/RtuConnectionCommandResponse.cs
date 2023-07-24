namespace ModbusServiceLibrary.ModbusConnection
{
	public enum RtuConnectionResponse
	{
		Disconnected,
		Connecting,
		Connected,
		ConnectionFailure,
		AlreadyConnecting,
		AlreadyDisconnected,
		AlreadyConnected,
		CommandExecuted,
		CommandFailed
	}
}
