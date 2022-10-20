using ModelWcfServiceLibrary.FileAccessing;
using ModelWcfServiceLibrary.Model.RTU;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ModelWcfServiceLibrary.Repository
{
    /// <summary>
    /// Communication with a JSON file where RTU static data are stored.
    /// </summary>
    public class JsonRtuRepository : IRtuRepository
    {
        /// <summary>
        /// List of RTUs read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
        /// </summary>
        public List<RTU> RtuList { get; set; }

        public IFileAccess JsonFileAccess { get; set; }
        const string fileName = @".\..\..\Resources\RTUs.json";
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);


        public JsonRtuRepository(IFileAccess fileAccess)
        {
            JsonFileAccess = fileAccess;
            RtuList = new List<RTU>();
            Deserialize();
        }

        /// <summary>
        /// Saves the current state of the RTUs to a JSON file
        /// </summary>
        public void Serialize()
        { 
            string jsonString = CreateJsonString(RtuList);
            JsonFileAccess.SaveToFile(filePath, jsonString);
        }

        /// <summary>
        /// Converts list of RTUs to JSON string
        /// </summary>
        /// <param name="rtuList">List of RTUs to convert to JSON string</param>
        /// <returns>JSON string</returns>
        public string CreateJsonString(List<RTU> rtuList)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(rtuList, options);
        }

        /// <summary>
        ///  Stores RTUs data from JSON file in the <c>RtuList</c>
        /// </summary>
        public void Deserialize()
        {
            string jsonString = JsonFileAccess.ReadFile(filePath);
            RtuList = JsonSerializer.Deserialize<List<RTU>>(jsonString);
        }


        /// <summary>
        /// Gets the RTU with specified ID
        /// </summary>
        /// <param name="rtuID">Unique identification number for the RTU</param>
        /// <returns>RTU with the given ID. If RTU with that ID doesn't exist, it will return <c>null</c></returns>
        public RTU GetRTUByID(int rtuID)
        {
            return RtuList.SingleOrDefault(t => t.ID == rtuID);
        }
    }
}
