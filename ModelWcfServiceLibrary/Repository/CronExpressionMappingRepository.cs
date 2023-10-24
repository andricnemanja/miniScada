﻿using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using ModelWcfServiceLibrary.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Repository
{
	public class CronExpressionMappingRepository : ICronExpressionMappingRepository
	{
		/// <summary>
		/// Provides functionality to serialize and deserialize <see cref="ModelCronExpressionMapping"/> list to JSON file.
		/// </summary>
		private readonly IListSerializer<ModelCronExpressionMapping> serializer;

		/// <summary>
		/// List of the CronExpressionMappings.
		/// </summary>
		public List<ModelCronExpressionMapping> CronExpressionMappingList { get; private set; }

		public CronExpressionMappingRepository(IListSerializer<ModelCronExpressionMapping> serializer)
		{
			this.serializer = serializer;
			CronExpressionMappingList = new List<ModelCronExpressionMapping>();
		}

		/// <summary>
		/// Saves the current state of the List to a JSON file.
		/// </summary>
		public void Serialize()
		{
			serializer.Serialize(CronExpressionMappingList);
		}

		/// <summary>
		/// Deserializes list from its JSON file.
		/// </summary>
		public void Deserialize()
		{
			CronExpressionMappingList = serializer.Deserialize();
		}

		/// <summary>
		/// Gets a certain mapping by its ID.
		/// </summary>
		/// <param name="id">ID of the cron expression mapping.</param>
		/// <returns>Cron expression mapping.</returns>
		public ModelCronExpressionMapping GetByID(int id)
		{
			return CronExpressionMappingList.SingleOrDefault(m => m.Id == id);
		}
	}
}