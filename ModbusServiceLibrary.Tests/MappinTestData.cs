using System.Collections.Generic;
using ModbusServiceLibrary.ModelServiceReference;


namespace ModbusServiceLibrary.Tests
{
	public static class MappinTestData
	{
		public static List<ModelAnalogSignalMapping> GetAnalogSignalMappingsTestList()
		{
			return new List<ModelAnalogSignalMapping>()
			{
				new ModelAnalogSignalMapping()
				{
					Id = 1,
					K = 0.008,
					N = -40
				},
				new ModelAnalogSignalMapping()
				{
					Id = 2,
					K = 0.1,
					N = -300
				},
				new ModelAnalogSignalMapping()
				{
					Id = 3,
					K = 0.02,
					N = -100
				},
				new ModelAnalogSignalMapping()
				{
					Id = 4,
					K = 0.01,
					N = -100
				},
				new ModelAnalogSignalMapping()
				{
					Id = 5,
					K = 0.008,
					N = -40
				}

			};
		}

		public static List<ModelDiscreteSignalMapping> GetDiscreteSignalMappingsTestList()
		{
			return new List<ModelDiscreteSignalMapping>()
			{
				new ModelDiscreteSignalMapping()
				{
					Id = 1,
					Name = "test",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "Error" },
						{ 1, "Open" },
						{ 2, "Close" },
						{ 3, "Transit" }
					}
				},
				new ModelDiscreteSignalMapping()
				{
					Id = 2,
					Name = "test2",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "Error" },
						{ 1, "On" },
						{ 2, "Off" },
						{ 3, "Transit" }
					}
				},
				new ModelDiscreteSignalMapping()
				{
					Id = 3,
					Name = "test",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "On" },
						{ 1, "Off" },
					}
				},
			};
		}
	}
}
