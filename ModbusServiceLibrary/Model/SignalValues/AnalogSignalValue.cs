using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	/// <summary>
	/// Class <see cref="AnalogSignalValue"/> models value of the analog signal.
	/// </summary>
	public class AnalogSignalValue
	{
		/// <summary>
		/// Analog signal static data.
		/// </summary>
		public AnalogSignal AnalogSignal { get; set; }

		/// <summary>
		/// Value of the analog signal.
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignalValue"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">An instance of the <see cref="ModelServiceReference.AnalogSignal"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public AnalogSignalValue(ModelServiceReference.AnalogSignal analogSignalStaticData)
		{
			AnalogSignal = new AnalogSignal(analogSignalStaticData);
			Value = 0;
		}

		public AnalogSignalValue() {}
	}
}