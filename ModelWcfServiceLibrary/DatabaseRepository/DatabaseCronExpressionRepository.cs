using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseCronExpressionRepository : IDatabaseCronExpressionRepository
	{
		MiniScadaDBEntities miniScadaDB;

		public List<ModelCronExpressionMapping> CronExpressionList { get; private set; }

		public DatabaseCronExpressionRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			CronExpressionList = new List<ModelCronExpressionMapping>();
		}

		public void MapFromDatabase()
		{
			List<DbCronExpression> cronExpressionsDB = miniScadaDB.DbCronExpressions.ToList();

			foreach (var cron in cronExpressionsDB)
			{
				ModelCronExpressionMapping newCronExpression = new ModelCronExpressionMapping()
				{
					Id = cron.cron_id,
					Name = cron.cron_name,
					Start = cron.cron_start,
					End = cron.cron_end,
					RecurrencePeriod = cron.recurrence_period,
					RecurrenceType = (ModelCronExpressionRecurrenceType)cron.recurrence_type
				};

				CronExpressionList.Add(newCronExpression);
			}
		}

		public ModelCronExpressionMapping GetCronExpressionByID(int id)
		{
			return CronExpressionList.SingleOrDefault(m => m.Id == id);
		}
	}
}
