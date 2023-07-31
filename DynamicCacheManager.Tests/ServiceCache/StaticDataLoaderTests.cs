using System.Collections.Generic;
using DynamicCacheManager.DynamicCacheClient;
using DynamicCacheManager.Model;
using DynamicCacheManager.ModelServiceReference;
using DynamicCacheManager.ServiceCache;
using Moq;
using Xunit;

namespace DynamicCacheManager.Tests.ResultProcessing
{
	public class StaticDataLoaderTests
	{
		private readonly IStaticDataLoader staticDataLoader;
		private readonly Mock<IModelService> modelServiceMock;
		private readonly Mock<IDynamicCacheClient> dynamicCacheClientMock;
		public StaticDataLoaderTests() 
		{
			modelServiceMock = new Mock<IModelService>();
			dynamicCacheClientMock = new Mock<IDynamicCacheClient>();
			staticDataLoader = new StaticDataLoader(modelServiceMock.Object, dynamicCacheClientMock.Object);
		}

		[Fact]
		public void InitializeData()
		{
			//Arrange
			modelServiceMock.Setup(m => m.GetAllRTUs()).Returns(ModelServiceRtuTestData.GetRtuTestList());

			//Act
			List<Rtu> rtuList = staticDataLoader.InitializeData();
			List<Rtu> expectedRtuList = DynamicCacheRtuTestData.GetRtuTestList();

			//Assert
			Assert.Equivalent(expectedRtuList, rtuList);
		}
	}
}
