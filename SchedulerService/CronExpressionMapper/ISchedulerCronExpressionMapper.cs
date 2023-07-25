using SchedulerService.Model.CronExpression;
using System.Collections.Generic;

namespace SchedulerService.CronExpressionMapper
{
	public interface ISchedulerCronExpressionMapper
	{
		SchedulerCronExpression FindCronExpression(int mappingId);
		List<SchedulerCronExpression> ReadCronExpressions();
	}
}