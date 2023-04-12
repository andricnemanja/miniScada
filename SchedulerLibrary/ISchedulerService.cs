using System.ServiceModel;

namespace SchedulerLibrary
{
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISchedulerCallback))]
	public interface ISchedulerService
	{

	}
}
