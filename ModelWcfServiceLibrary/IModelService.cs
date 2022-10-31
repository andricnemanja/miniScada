using System.Collections.Generic;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.RTU;

namespace ModelWcfServiceLibrary
{
	/// <summary>
	/// Provides endpoints for Model Service
	/// </summary>
	[ServiceContract]
    public interface IModelService
    {
<<<<<<< HEAD
        /// <summary>
        /// Gets the list of RTUs from the repository.
        /// </summary>
        /// <returns>List of RTUs</returns>
        [OperationContract]
        List<RTU> GetStaticData();

        /// <summary>
        /// Gets the specific RTU via its ID number.
        /// </summary>
        /// <param name="id">Identification number that is unique for every RTU</param>
        /// <returns>RTU with the specified ID.</returns>
        [OperationContract]
        [FaultContract(typeof(ModelServiceException))]
=======
		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		[OperationContract]
        List<RTU> GetStaticData();
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		[OperationContract]
>>>>>>> 9e27fb551f1a77e880ea5e13e8455ad8bb04d5e8
        RTU GetRTU(int id);

    }
}
