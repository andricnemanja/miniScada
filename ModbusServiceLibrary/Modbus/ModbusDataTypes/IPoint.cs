namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public interface IPoint
	{
		int Id { get; }
		int SignalId { get; }
		int RtuId { get; }
		int Address { get; }
		int MappingId { get; }
	}
}
