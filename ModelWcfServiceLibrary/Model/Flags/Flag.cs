namespace ModelWcfServiceLibrary.Model.Flags
{
	public class Flag
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public FlagType Type { get; set; }
		public bool ReadAllowed { get; set; }
		public bool CommandAllowed { get; set; }
		public bool UserAssignable { get; set; }

	}
}
