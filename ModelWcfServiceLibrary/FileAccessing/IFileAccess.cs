using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.FileAccessing
{
    /// <summary>
    /// Accessing files for reading and writing 
    /// </summary>
    public interface IFileAccess
    {
        string ReadFile(string filePath);
        void SaveToFile(string filePath, string textToSave);
    }
}
