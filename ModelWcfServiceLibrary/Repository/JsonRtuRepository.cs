using ModelWcfServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ModelWcfServiceLibrary.Repository
{
    public class JsonRtuRepository : IRtuRepository
    {
        public List<RTU> RtuList { get; set; }
        const string fileName = @".\..\..\Resources\RTUs.json";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);


        public JsonRtuRepository()
        {
            RtuList = new List<RTU>();
            Deserialize();
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
            return RtuList.SingleOrDefault(t => t.ID == rtuID);
        }
    }
}
