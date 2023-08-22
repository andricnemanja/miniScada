using System.Collections.Generic;
using DynamicCacheManager.ModelServiceReference;

namespace DynamicCacheManager.Tests
{
	public static class ModelServiceRtuTestData
	{
		public static List<ModelRTU> GetRtuTestList()
		{
			List<ModelRTU> rtuList = new List<ModelRTU>()
			{
				new ModelRTU()
				{
					RTUData = new ModelRTUData
					{
						ID = 1,
						Name = "RTU 1",
						IpAddress = "127.0.0.1",
						Port = 502
					},
					AnalogSignals = new List<ModelAnalogSignal>()
					{
						new ModelAnalogSignal()
						{
							ID = 1,
							Name = "AnalogSignal 1",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 1,
							Deadband = 1
						},
						new ModelAnalogSignal()
						{
							ID = 2,
							Name = "AnalogSignal 2",
							Address = 5,
							AccessType = ModelSignalAccessType.Input,
							MappingId = 1,
							Deadband = 2
						},
						new ModelAnalogSignal()
						{
							ID = 3,
							Name = "AnalogSignal 3",
							Address = 7,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 3,
							Deadband = 3
						}
					},
					DiscreteSignals = new List<ModelDiscreteSignal>()
					{
						new ModelDiscreteSignal()
						{
							ID = 4,
							Name = "DiscreteSignal 1",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 2,
							SignalType = DiscreteSignalType.TwoBit
						},
						new ModelDiscreteSignal()
						{
							ID = 5,
							Name = "DiscreteSignal 2",
							Address = 1,
							AccessType = ModelSignalAccessType.Input,
							MappingId = 2,
							SignalType = DiscreteSignalType.TwoBit
						}
					}
				},
				new ModelRTU()
				{
					RTUData = new ModelRTUData
					{
						ID = 2,
						Name = "RTU 2",
						IpAddress = "127.0.0.1",
						Port = 503
					},
					AnalogSignals = new List<ModelAnalogSignal>()
					{
						new ModelAnalogSignal()
						{
							ID = 6,
							Name = "AnalogSignal 1",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 5,
							Deadband = 3
						},
						new ModelAnalogSignal()
						{
							ID = 7,
							Name = "AnalogSignal 2",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 5,
							Deadband = 3
						}
					},
					DiscreteSignals = new List<ModelDiscreteSignal>()
					{
						new ModelDiscreteSignal()
						{
							ID = 8,
							Name = "DiscreteSignal 1",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 1,
							SignalType = DiscreteSignalType.OneBit
						},
						new ModelDiscreteSignal()
						{
							ID = 9,
							Name = "DiscreteSignal 2",
							Address = 1,
							AccessType = ModelSignalAccessType.Output,
							MappingId = 1,
							SignalType = DiscreteSignalType.TwoBit
						}
					}
				}
			};


			return rtuList;
		
		}
	}
		
}
