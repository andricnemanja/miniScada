using System.IO;

namespace ModelWcfServiceLibrary.FileAccessing
{
	/// <summary>
	/// Class for accessing files for reading and writing 
	/// </summary>
	public sealed class FileAccess : IFileAccess
    {
		/// <summary>
		/// Read text file
		/// </summary>
		/// <param name="filePath">Relative path to the file</param>
		/// <returns>A string representing the text that was read from the file</returns>
		public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
		/// <summary>
		/// Save text to the file
		/// </summary>
		/// <param name="filePath">Relative path to the file</param>
		/// <param name="textToSave">Text that needs to be saved to the file</param>
		public void SaveToFile(string filePath, string textToSave)
        {
            File.WriteAllText(filePath, textToSave);
        }
    }
}
