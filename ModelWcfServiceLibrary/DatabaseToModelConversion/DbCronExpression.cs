using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.EntityDataModel
{
	public partial class DbCronExpression
	{
		public ModelCronExpressionMapping ToModel()
		{
			return new ModelCronExpressionMapping
			{
				Id = this.cron_id,
				Name = this.cron_name,
				Start = this.cron_start,
				End = this.cron_end,
				RecurrencePeriod = this.recurrence_period,
				RecurrenceType = (ModelCronExpressionRecurrenceType)this.recurrence_type
			};
		}
	}
}
