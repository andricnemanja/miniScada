using System.Collections.Generic;

namespace DynamicCacheManager.Model
{
	public class Rtu
	{
		public Rtu(int id, List<AnalogSignal> analogSignals, List<DiscreteSignal> discreteSignals)
		{
			Id = id;
			AnalogSignals = analogSignals;
			DiscreteSignals = discreteSignals;
		}

		public int Id { get; }
		public List<AnalogSignal> AnalogSignals { get; }
		public List<DiscreteSignal> DiscreteSignals { get; }
	}
}
