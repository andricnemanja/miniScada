using System.Collections.Generic;

namespace DynamicCacheManager.Model
{
	public interface ISignal
	{
		int Id { get; }
		int RtuId { get; }
		string Value { get; set; }
		List<int> Flags { get; }
	}
}