using System.Collections.Generic;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.Tests
{
	public static class RtuTestData
	{
		public static List<RTU> GetRtuTestList()
		{
			List<RTU> rtuList = new List<RTU>()
			{
				new RTU()
				{
					RTUData = new RTUData
					{
						ID = 1,
						Name = "RTU 1",
						IpAddress = "127.0.0.1",
						Port = 502
					},
					AnalogSignals = new List<AnalogSignal>()
					{
						new AnalogSignal()
						{
							ID = 1,
							Name = "AnalogSignal 1",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 1
						},
						new AnalogSignal()
						{
							ID = 2,
							Name = "AnalogSignal 2",
							Address = 5,
							AccessType = SignalAccessType.Output,
							MappingId = 2
						},
						new AnalogSignal()
						{
							ID = 3,
							Name = "AnalogSignal 3",
							Address = 7,
							AccessType = SignalAccessType.Output,
							MappingId = 3
						}
					},
					DiscreteSignals = new List<DiscreteSignal>()
					{
						new DiscreteSignal()
						{
							ID = 6,
							Name = "DiscreteSignal 1",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 1,
							SignalType = DiscreteSignalType.OneBit
						},
						new DiscreteSignal()
						{
							ID = 7,
							Name = "DiscreteSignal 2",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 1,
							SignalType = DiscreteSignalType.TwoBit
						}
					}
				},
				new RTU()
				{
					RTUData = new RTUData
					{
						ID = 2,
						Name = "RTU 2",
						IpAddress = "127.0.0.1",
						Port = 503
					},
					AnalogSignals = new List<AnalogSignal>()
					{
						new AnalogSignal()
						{
							ID = 4,
							Name = "AnalogSignal 1",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 5
						},
						new AnalogSignal()
						{
							ID = 5,
							Name = "AnalogSignal 2",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 5
						}
					},
					DiscreteSignals = new List<DiscreteSignal>()
					{
						new DiscreteSignal()
						{
							ID = 9,
							Name = "DiscreteSignal 1",
							Address = 1,
							AccessType = SignalAccessType.Output,
							MappingId = 1,
							SignalType = DiscreteSignalType.OneBit
						},
						new DiscreteSignal()
						{
							ID = 10,
							Name = "DiscreteSignal 2",
							Address = 1,
							AccessType = SignalAccessType.Output,
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
