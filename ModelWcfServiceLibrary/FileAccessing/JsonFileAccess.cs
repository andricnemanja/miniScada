using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.FileAccessing
{
    public class JsonFileAccess : IFileAccess
    {
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void SaveToFile(string filePath, string textToSave)
        {
            File.WriteAllText(filePath, textToSave);
        }
    }
}
