namespace Scheduler.PointTypeScan
{
	public interface IScheduler
	{
		int seconds { get; }

		void StartScheduler();
	}
}
