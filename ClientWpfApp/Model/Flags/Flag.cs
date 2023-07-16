namespace ClientWpfApp.Model.Flags
{
	public class Flag
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public FlagType Type { get; set; }

		public Flag(string name, string description, FlagType type)
		{
			Name = name;
			Description = description;
			Type = type;
		}
	}
}
