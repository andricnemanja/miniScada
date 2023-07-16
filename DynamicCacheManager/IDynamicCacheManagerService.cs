using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;

namespace DynamicCacheManager
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface IDynamicCacheManagerService
	{
		[OperationContract(IsOneWay = true)]
		void ProcessCommandResult(CommandResultBase commandResult);
	}
}
