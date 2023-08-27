using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;
using System.ServiceModel;

namespace ModelWcfServiceLibrary
{
	[ServiceContract]
	public interface IModelScheduler
	{
		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		[OperationContract]
		List<ModelRTU> GetAllRTUs();
		/// <summary>
		/// Gets all signal scan periods.
		/// </summary>
		/// <returns>List of signal scan periods.</returns>
		[OperationContract]
		IEnumerable<SignalScanPeriodMapping> GetSignalScanPeriodMappings();
		/// <summary>
		/// Gets all cron expressions
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		IEnumerable<ModelCronExpressionMapping> GetCronExpressionMappings();


	}
}
