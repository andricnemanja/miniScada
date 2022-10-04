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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IModelService
    {
        [OperationContract]
        List<RTU> GetStaticData();

        [OperationContract]
        RTU GetRTU(int id);

    }
}
