using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	/// <summary>
	/// Class <see cref="DiscreteSignalValue"/> models value of the discrete signal.
	/// </summary>
	public class DiscreteSignalValue
	{
		/// <summary>
		/// Discrete signal.
		/// </summary>
		public DiscreteSignal DiscreteSignal { get; set; }
	
		/// <summary>
		/// Value of the discrete signal.
		/// </summary>
		public bool[] Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignalValue"/> class.
		/// </summary>
		/// <param name="discreteSignalStaticData">Discrete signal static data.</param>
		public DiscreteSignalValue(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			DiscreteSignal = new DiscreteSignal(discreteSignalStaticData);
			Value[0] = false;
		}

		public DiscreteSignalValue() {}
	}
}