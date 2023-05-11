using System.ServiceModel;

namespace SchedulerServiceLibrary
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface ISchedulerService
	{
		//[OperationContract]
		//int UselessMethod();
	}
}
