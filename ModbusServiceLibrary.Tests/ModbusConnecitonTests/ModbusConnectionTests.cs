using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.ServiceReader;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusConnecitonTests
{
	public class ModbusConnectionTests
	{
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		public void FindRtu_RtuExist(int rtuId)
		{
			var modelServiceReaderMock = new Mock<IModelServiceReader>();
			modelServiceReaderMock.Setup(x => x.ReadAllRTUs()).Returns(RtuTestData.GetRtuTestList());
			ModbusConnection modbusConnection = new ModbusConnection(modelServiceReaderMock.Object);
			modbusConnection.InitializeData();
			RTU expectedRtu = RtuTestData.GetRtuTestList().Where(r => r.RTUData.ID == rtuId).FirstOrDefault();

			RTU findRtu = modbusConnection.FindRtu(rtuId);

			Assert.Equal(expectedRtu.RTUData.ID, findRtu.RTUData.ID);
		}
	}
}
