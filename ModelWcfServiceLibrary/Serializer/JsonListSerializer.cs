﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ModelWcfServiceLibrary.FileAccessing;

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
		private readonly IFileAccess fileAccess;

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonListSerializer"/>
		/// </summary>
		/// <param name="fileAccess">Instance of the <see cref="IFileAccess"/> class</param>
		/// <param name="relativeFilePath">Relative path to the JSON file</param>
		public JsonListSerializer(IFileAccess fileAccess, string relativeFilePath)
		{
			this.fileAccess = fileAccess;
			this.filePath = Path.GetFullPath(baseFilePath + relativeFilePath);
		}
		/// <summary>
		/// Read list from a JSON file.
		/// </summary>
		/// <returns>List of objects</returns>
		public List<T> Deserialize()
		{
			string jsonString = fileAccess.ReadFile(filePath);
			return JsonSerializer.Deserialize<List<T>>(jsonString);
		}
		/// <summary>
		/// Saves the current state of the List to a JSON file
		/// </summary>
		/// <param name="rtuList">List of objects to be saved</param>
		public void Serialize(List<T> rtuList)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(rtuList, options);
			fileAccess.SaveToFile(filePath, jsonString);
		}
	}
}
