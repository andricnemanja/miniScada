using DynamicCacheManager.ResultsProcessing;
using ModbusServiceLibrary.CommandResult;
using Moq;
using Xunit;

namespace DynamicCacheManager.Tests.DynamicCacheService
{
	public class DynamicCacheServiceTests
	{
		private readonly IDynamicCacheManagerService dynamicCacheManagerService;
		private readonly Mock<ICommandResultQueue> commandResultQueueMock;
		public DynamicCacheServiceTests()
		{
			commandResultQueueMock = new Mock<ICommandResultQueue>();
			dynamicCacheManagerService = new DynamicCacheManagerService(commandResultQueueMock.Object);
		}

		[Fact]
		public void ProcessCommandResult()
		{
			//Arrange
			CommandResultBase commandResultBase = new ReadSingleAnalogSignalResult(1, 1, 1);

			//Act
			dynamicCacheManagerService.ProcessCommandResult(commandResultBase);

			//Assert
			commandResultQueueMock.Verify(c => c.AddToQueue(commandResultBase));
		}
	}
}
