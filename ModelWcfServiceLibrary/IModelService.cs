using ModelWcfServiceLibrary.Model.RTU;
using System.Collections.Generic;
using System.ServiceModel;

namespace ModelWcfServiceLibrary
{
    [ServiceContract]
    public interface IModelService
    {
        [OperationContract]
        List<RTU> GetStaticData();

        [OperationContract]
        RTU GetRTU(int id);

    }
}
