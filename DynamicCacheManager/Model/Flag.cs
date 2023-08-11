using DynamicCacheManager.ModelServiceReference;

namespace DynamicCacheManager.Model
{
	public class Flag
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public Flag(ModelFlag modelFlag)
		{
			ID= modelFlag.ID;
			Name= modelFlag.Name;
		}

		public Flag(int iD, string name)
		{
			ID = iD;
			Name = name;
		}
	}
}
