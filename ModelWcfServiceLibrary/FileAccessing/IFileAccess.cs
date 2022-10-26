namespace ModelWcfServiceLibrary.FileAccessing
{
    /// <summary>
    /// Accessing files for reading and writing 
    /// </summary>
    public interface IFileAccess
	{
		/// <summary>
		/// Read text file
		/// </summary>
		/// <param name="filePath">Relative path to the file</param>
		/// <returns>A string representing the text that was read from the file</returns>
		string ReadFile(string filePath);
		/// <summary>
		/// Save text to the file
		/// </summary>
		/// <param name="filePath">Relative path to the file</param>
		/// <param name="textToSave">Text that needs to be saved to the file</param>
		void SaveToFile(string filePath, string textToSave);
    }
}
