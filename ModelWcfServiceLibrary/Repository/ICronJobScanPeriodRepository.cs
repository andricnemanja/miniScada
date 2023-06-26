using ModelWcfServiceLibrary.Model.CronJobPeriodMapping;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Repository
{
	public interface ICronJobScanPeriodRepository
	{
		List<ModelCronJobPeriodMapping> CronJobPeriodMappingList { get; }

		void Deserialize();
		ModelCronJobPeriodMapping GetByID(int id);
		void Serialize();
	}
}