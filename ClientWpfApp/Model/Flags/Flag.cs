using ClientWpfApp.ModelServiceReference;

namespace ClientWpfApp.Model.Flags
{
	public class Flag
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public FlagType Type { get; set; }

		public Flag(string name, string description, FlagType type)
		{
			Name = name;
			Description = description;
			Type = type;
		}

		public Flag(ModelFlag modelFlag)
		{
			ID = modelFlag.ID;
			Name = modelFlag.Name;
			Description = modelFlag.Description;
			Type = (FlagType)modelFlag.Type;
		}
	}
}
