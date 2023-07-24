using System.ServiceModel;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	/// <summary>
	/// 
	/// </summary>
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface IModbusService
	{
		[OperationContract(IsOneWay = true)]
		void ReceiveCommand(RtuCommandBase commandResult);
	}
}
