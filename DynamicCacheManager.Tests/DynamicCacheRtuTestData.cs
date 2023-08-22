using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.Tests
{
	public static class DynamicCacheRtuTestData
	{
		public static List<Rtu> GetRtuTestList()
		{
			List<Rtu> rtuList = new List<Rtu>()
			{
				new Rtu(1, 
					new List<AnalogSignal>()
					{
						new AnalogSignal(1, 1, 1),
						new AnalogSignal(2, 1, 2),
						new AnalogSignal(3, 1, 3)
					},
					new List<DiscreteSignal>()
					{
						new DiscreteSignal(4, 1),
						new DiscreteSignal(5, 1)
					},
					new List<int>()
				),
				new Rtu(2,
					new List<AnalogSignal>()
					{
						new AnalogSignal(6, 2, 3),
						new AnalogSignal(7, 2, 3)
					},
					new List<DiscreteSignal>()
					{
						new DiscreteSignal(8, 2),
						new DiscreteSignal(9, 2)
					},
					new List<int>()
				)
			};

			return rtuList;
		
		}
	}
		
}
