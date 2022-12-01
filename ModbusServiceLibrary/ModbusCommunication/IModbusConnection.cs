namespace ModbusServiceLibrary.ModbusCommunication
{
	public interface IModbusConnection
	{
		bool TryConnectToRtu(int rtudId);
	}
}