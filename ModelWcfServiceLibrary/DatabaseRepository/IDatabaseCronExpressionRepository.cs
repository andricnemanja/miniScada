using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseCronExpressionRepository
	{
		List<ModelCronExpressionMapping> CronExpressionList { get; }

		ModelCronExpressionMapping GetCronExpressionByID(int id);
		void MapFromDatabase();
	}
}