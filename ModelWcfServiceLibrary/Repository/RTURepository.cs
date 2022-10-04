using ModelWcfServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Repository
{
    public class RTURepository
    {
        public List<RTU> RtuList { get; }
        const string fileName = @".\..\..\Resources\RTUs.json";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);


        public RTURepository()
        {
            RtuList = new List<RTU>();
        }


        public void Serialize()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(RtuList, options);


            File.WriteAllText(filePath, jsonString);
        }


        public void Deserialize()
        {
            string jsonString = File.ReadAllText(filePath);
            RtuList = JsonSerializer.Deserialize<List<RTU>>(jsonString);
        }


        public RTU GetRTUByID(int rtuID)
        {
            return (RTU)RtuList.Where(t => t.ID == rtuID);
        }
    }
}
