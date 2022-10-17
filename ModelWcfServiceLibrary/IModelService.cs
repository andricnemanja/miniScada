using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
