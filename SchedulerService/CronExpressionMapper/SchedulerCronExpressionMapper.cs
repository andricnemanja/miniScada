using SchedulerService.Model.CronExpression;
using SchedulerService.ModelServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace SchedulerService.CronExpressionMapper
{
	public class SchedulerCronExpressionMapper : ISchedulerCronExpressionMapper
	{
		private readonly IModelService modelService;

		/// <summary>
		/// List of cron expressions.
		/// </summary>
		public List<SchedulerCronExpression> cronExpressions = new List<SchedulerCronExpression>();

		/// <summary>
		/// Initializes instance of <see cref="SchedulerCronExpressionMapper"/> class.
		/// </summary>
		/// <param name="modelService">Model service.</param>
		public SchedulerCronExpressionMapper(IModelService modelService)
		{
			this.modelService = modelService;
			cronExpressions = ReadCronExpressions();
		}

		/// <summary>
		/// Reads cron expression mapping from <see cref="ModelService"/>
		/// </summary>
		/// <returns></returns>
		public List<SchedulerCronExpression> ReadCronExpressions()
		{
			List<SchedulerCronExpression> expressions = new List<SchedulerCronExpression>();

			foreach (var expression in modelService.GetCronExpressionMappings())
			{
				SchedulerCronExpression newExpression = new SchedulerCronExpression()
				{
					Id = expression.Id,
					Name = expression.Name,
					Start = expression.Start,
					CronExpressionScheduler = CronExpressionConverter.CronConvert(expression.RecurrenceType, expression.RecurrencePeriod),
					End = expression.End,
				};

				expressions.Add(newExpression);
			}

			return expressions;
		}

		/// <summary>
		/// Finds instance of <see cref="SchedulerCronExpression"/> by its Id.
		/// </summary>
		/// <param name="mappingId">Id of mapping.</param>
		/// <returns>Instance of <see cref="SchedulerCronExpression"/>.</returns>
		public SchedulerCronExpression FindCronExpression(int mappingId)
		{
			return cronExpressions.SingleOrDefault(m => m.Id == mappingId);
		}
	}
}
