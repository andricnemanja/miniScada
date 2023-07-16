using System.Collections.Generic;
using Redis.OM.Modeling;

namespace DynamicCacheManager.Model
{
	[Document(StorageType = StorageType.Json, Prefixes = new []{"Rtu"})]
	public class Rtu
	{
		public Rtu(int id, List<AnalogSignal> analogSignals, List<DiscreteSignal> discreteSignals, List<string> flags)
		{
			Id = id;
			AnalogSignals = analogSignals;
			DiscreteSignals = discreteSignals;
			Flags = flags;
		}
		[RedisIdField]
		[Indexed]
		public int Id { get; }
		[Indexed(CascadeDepth = 1)]
		public List<AnalogSignal> AnalogSignals { get; }
		[Indexed(CascadeDepth = 1)]
		public List<DiscreteSignal> DiscreteSignals { get; }
		[Indexed]
		public List<string> Flags { get; }
	}
}
