using System.ServiceModel;

namespace SchedulerLibrary
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface ISchedulerService
	{
		//[OperationContract]
		//int UselessMethod();
	}
}
