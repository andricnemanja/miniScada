namespace ModelWcfServiceLibrary.Model.Flags
{
	public sealed class ModelFlag
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ModelFlagType Type { get; set; }
		public bool ReadAllowed { get; set; }
		public bool CommandAllowed { get; set; }
		public bool UserAssignable { get; set; }

	}
}
