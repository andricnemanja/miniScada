using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Repository
{
	public interface ICronExpressionMappingRepository
	{
		List<CronExpressionMapping> CronExpressionMappingList { get; }

		void Deserialize();
		CronExpressionMapping GetByID(int id);
		void Serialize();
	}
}