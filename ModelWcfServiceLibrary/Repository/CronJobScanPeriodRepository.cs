using ModelWcfServiceLibrary.Model.CronJobPeriodMapping;
using ModelWcfServiceLibrary.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Repository
{
	public class CronJobScanPeriodRepository : ICronJobScanPeriodRepository
	{
		private readonly IListSerializer<ModelCronJobPeriodMapping> serializer;

		public List<ModelCronJobPeriodMapping> CronJobPeriodMappingList { get; private set; }

		public CronJobScanPeriodRepository(IListSerializer<ModelCronJobPeriodMapping> serializer)
		{
			this.serializer = serializer;
			CronJobPeriodMappingList = new List<ModelCronJobPeriodMapping>();
		}

		public void Serialize()
		{
			serializer.Serialize(CronJobPeriodMappingList);
		}

		public void Deserialize()
		{
			CronJobPeriodMappingList = serializer.Deserialize();
		}

		public ModelCronJobPeriodMapping GetByID(int id)
		{
			return CronJobPeriodMappingList.SingleOrDefault(x => x.Id == id);
		}
	}
}
