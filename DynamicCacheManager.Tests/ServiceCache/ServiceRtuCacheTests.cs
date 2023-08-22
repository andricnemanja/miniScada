using DynamicCacheManager.Model;
using DynamicCacheManager.ServiceCache;
using Moq;
using Xunit;

namespace DynamicCacheManager.Tests.ServiceCache
{
	public class DynamicCacheServiceTests
	{
		private readonly IServiceRtuCache serviceRtuCache;
		private readonly Mock<IStaticDataLoader> staticDataLoaderMock;
		public DynamicCacheServiceTests()
		{
			staticDataLoaderMock = new Mock<IStaticDataLoader>();
			staticDataLoaderMock.Setup(x => x.InitializeRtuData()).Returns(DynamicCacheRtuTestData.GetRtuTestList());
			serviceRtuCache = new ServiceRtuCache(staticDataLoaderMock.Object);
			serviceRtuCache.InitializeData();
		}

		[Fact]
		public void InitializeData()
		{
			//Act
			serviceRtuCache.InitializeData();

			//Assert
			Assert.Equivalent(DynamicCacheRtuTestData.GetRtuTestList(), serviceRtuCache.RtuList);
			staticDataLoaderMock.Verify(s => s.InitializeRtuData());
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(1, 4)]
		[InlineData(2, 6)]
		[InlineData(2, 8)]
		public void FindSignal_SignalExists(int rtuId, int signalId)
		{
			//Act
			ISignal signal = serviceRtuCache.GetSignal(rtuId, signalId);

			//Assert
			Assert.Equal(signalId, signal.Id);
		}

		[Theory]
		[InlineData(1, 6)]
		[InlineData(1, 8)]
		[InlineData(2, 1)]
		[InlineData(2, 4)]
		public void FindSignal_SignalDoesNotExists(int rtuId, int signalId)
		{
			//Act
			ISignal signal = serviceRtuCache.GetSignal(rtuId, signalId);

			//Assert
			Assert.Null(signal);
		}

		[Theory]
		[InlineData(3, 1)]
		[InlineData(-3, 1)]
		public void FindSignal_RtuDoesNotExists(int rtuId, int signalId)
		{
			//Act
			ISignal signal = serviceRtuCache.GetSignal(rtuId, signalId);

			//Assert
			Assert.Null(signal);
		}
	}
}
