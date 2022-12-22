using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	/// <summary>
	/// Class <see cref="AnalogSignalValue"/> models value of the analog signal.
	/// </summary>
	public class AnalogSignalValue
	{
		/// <summary>
		/// Analog signal
		/// </summary>
		public AnalogSignal AnalogSignal { get; set; }

		/// <summary>
		/// Value of the analog signal
		/// </summary>
		public int Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AnalogSignalValue"/> class.
		/// </summary>
		/// <param name="analogSignalStaticData">Analog signal static data.</param>
		public AnalogSignalValue(ModelServiceReference.AnalogSignal analogSignalStaticData)
		{
			AnalogSignal = new AnalogSignal(analogSignalStaticData);
			Value = 0;
		}
	}
}