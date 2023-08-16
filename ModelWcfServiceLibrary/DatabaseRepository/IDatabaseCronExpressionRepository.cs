using ModelWcfServiceLibrary.Model.CronExpressionMappings;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseCronExpressionRepository
	{
		ModelCronExpressionMapping GetCronExpressionByID(int id);
		void MapFromDatabase();
	}
}