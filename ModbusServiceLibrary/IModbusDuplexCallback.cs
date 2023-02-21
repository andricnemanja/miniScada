using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary
{
	[ServiceContract]
	public interface IModbusDuplexCallback
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="commandResult"></param>
		[OperationContract(IsOneWay = true)]
		void ReceiveCommandResult(CommandResultBase commandResult);
	}
}
