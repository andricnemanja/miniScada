namespace ModbusServiceLibrary.Model.SignalMapping
{
	public class SignalMapping
	{
		public int RtuId { get; set; }
		public int AnalogSignalId { get; set; }
		public int MinSensorValue { get; set; }
		public int MaxSensorValue { get; set; }
		public int MinRealValue { get; set; }
		public int MaxRealValue { get; set;}
		public string Unit { get; set; }
	}
}
