using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Repository
{
	public interface ICronExpressionMappingRepository
	{
		List<ModelCronExpressionMapping> CronExpressionMappingList { get; }

		void Deserialize();
		ModelCronExpressionMapping GetByID(int id);
		void Serialize();
	}
}