using ModelWcfServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
