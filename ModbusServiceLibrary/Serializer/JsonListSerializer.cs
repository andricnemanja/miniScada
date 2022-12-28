using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ModelWcfServiceLibrary.Serializer
{
	/// <summary>
	/// Provides functionality to serialize and deserialize RTU list to JSON file
	/// </summary>
	public sealed class JsonListSerializer<T> : IListSerializer<T>
	{
		/// <summary>
		/// String for getting to the project base directory from current directory
		/// </summary>
		private const string twoDirectoriesBack = @".\..\..";
		/// <summary>
		/// Base directory of the project
		/// </summary>
		private readonly string baseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, twoDirectoriesBack);
		/// <summary>
		/// Absolute path to the JSON file
		/// </summary>
		private readonly string filePath;

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonListSerializer"/>
		/// </summary>
		/// <param name="relativeFilePath">Relative path to the JSON file</param>
		public JsonListSerializer(string relativeFilePath)
		{
			this.filePath = Path.GetFullPath(baseFilePath + relativeFilePath);
		}
		/// <summary>
		/// Read serialized object from a JSON file.
		/// </summary>
		/// <returns>List of saved objects</returns>
		public List<T> Deserialize()
		{
			string jsonString = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<List<T>>(jsonString);
		}
		/// <summary>
		/// Saves the current state of the RTUs to a JSON file
		/// </summary>
		/// <param name="listToSerialize">List to be saved</param>
		public void Serialize(List<T> listToSerialize)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(listToSerialize, options);
			File.WriteAllText(filePath, jsonString);
		}
	}
}
