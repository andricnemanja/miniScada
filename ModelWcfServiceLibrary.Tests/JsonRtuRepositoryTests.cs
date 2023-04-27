using ModelWcfServiceLibrary.FileAccessing;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;
using ModelWcfServiceLibrary.Serializer;
using Moq;
using Xunit;

namespace ModelWcfServiceLibrary.Tests
{
	public class JsonRtuRepositoryTests
	{
		private readonly RtuRepository repository;

		public JsonRtuRepositoryTests()
		{
			repository = CreateTestJsonRtuRepository();
		}

		[Fact]
		public void GetRTUByID_IdThatExists()
		{
			RTU rtuByID = repository.GetRTUByID(102);

			Assert.Equal("RTU2", rtuByID.RTUData.Name);
		}


		[Fact]
		public void GetRTUByID_IdThatDoesNotExist()
		{
			RTU rtuByID = repository.GetRTUByID(100);

			Assert.Null(rtuByID);
		}

		private RtuRepository CreateTestJsonRtuRepository()
		{
			var fileAccessMock = new Mock<IFileAccess>();
			fileAccessMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(GetTestJsonString());
			JsonListSerializer<RTU> jsonRtuSerializer = new JsonListSerializer<RTU>(fileAccessMock.Object, It.IsAny<string>());
			RtuRepository rtuRepository = new RtuRepository(jsonRtuSerializer);
			rtuRepository.Deserialize();

			return rtuRepository;
		}

		private string GetTestJsonString()
		{
			return @"[
					  {
						""Name"": ""RTU1"",
						""ID"": 101,
						""Address"": ""127.0.0.1"",
						""Port"": 502,
						""AnalogSignals"": [
						  {
							""ID"": 1,
							""Address"": 1,
							""Name"": ""Analog signal 1""
						  },
						  {
							""ID"": 2,	
							""Address"": 2,
							""Name"": ""Analog signal 2""
						  }
						],
						""DiscreteSignals"": [
						  {
							""ID"": 1,
							""Address"": 1,
							""Name"": ""Discrete signal 1""
						  }
						]
					  },
					  {
						""Name"": ""RTU2"",
						""ID"": 102,
						""Address"": ""127.0.0.1"",
						""Port"": 503,
						""AnalogSignals"": [
						  {
							""ID"": 1,
							""Address"": 1,
							""Name"": ""Analog signal 1""
						  },
						  {
							""ID"": 2,
							""Address"": 4,
							""Name"": ""Analog signal 2""
						  }
						],
						""DiscreteSignals"": [
						  {
							""ID"": 1,
							""Address"": 2,
							""Name"": ""Discrete signal 1""
						  }
						]
					  }
					]";
		}
	}
}
