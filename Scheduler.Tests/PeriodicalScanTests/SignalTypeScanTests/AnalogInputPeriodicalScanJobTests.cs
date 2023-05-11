using Moq;
using SchedulerLibrary.ModbusServiceReference;
using SchedulerLibrary.RtuConfiguration;
using Xunit;

namespace SchedulerLibrary.Tests.PeriodicalScan.SignalTypeScan
{
	public class AnalogInputPeriodicalScanJobTests
	{
		[Fact]
		public void Execute_ShouldScanAllAnalogInputTypeSignals()
		{
			// Arrange
			var rtuConfigurationMock = new Mock<IRtuConfiguration>();
			var modbusDuplexMock = new Mock<IModbusDuplex>();

		}
	}
}
