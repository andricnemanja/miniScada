using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	/// <summary>
	/// Repository of the Cron expressions. It stores cron expression list.
	/// </summary>
	public class DatabaseCronExpressionRepository : IDatabaseCronExpressionRepository
	{
		/// <summary>
		/// Context class of the database.
		/// </summary>
		MiniScadaDBEntities miniScadaDB;

		/// <summary>
		/// List of the CronExpressionMappings.
		/// </summary>
		public List<ModelCronExpressionMapping> CronExpressionList { get; private set; }

		/// <summary>
		/// Initializes new <see cref="DatabaseCronExpressionRepository"/> class.
		/// </summary>
		public DatabaseCronExpressionRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			CronExpressionList = new List<ModelCronExpressionMapping>();
		}

		/// <summary>
		/// Maps data from the database to the service model.
		/// </summary>
		public void MapFromDatabase()
		{
			List<DbCronExpression> cronExpressionsDB = miniScadaDB.DbCronExpressions.AsNoTracking().ToList();

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

		/// <summary>
		/// Gets a certain mapping by its ID.
		/// </summary>
		/// <param name="id">ID of the cron expression mapping.</param>
		/// <returns>Cron expression mapping.</returns>
		public ModelCronExpressionMapping GetCronExpressionByID(int id)
		{
			return CronExpressionList.SingleOrDefault(m => m.Id == id);
		}
	}
}
