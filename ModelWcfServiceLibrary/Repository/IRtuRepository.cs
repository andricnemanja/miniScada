using ModelWcfServiceLibrary.Model.RTU;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Repository
{
    public interface IRtuRepository
    {
        List<RTU> RtuList { get; set; }

        void Serialize();
        void Deserialize();
        RTU GetRTUByID(int rtuID);
    }
}
