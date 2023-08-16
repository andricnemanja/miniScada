using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelWcfServiceLibrary.EntityDataModel
{
	public partial class MiniScadaDB : DbContext
	{
		public MiniScadaDB()
			: base("name=MiniScadaDB")
		{
		}

		public virtual DbSet<AnalogSignalMappingDB> AnalogSignalMappings { get; set; }
		public virtual DbSet<CronExpressionDB> CronExpressions { get; set; }
		public virtual DbSet<DiscreteSignalMappingDB> DiscreteSignalMappings { get; set; }
		public virtual DbSet<RtuDB> Rtus { get; set; }
		public virtual DbSet<ScanPeriodDB> ScanPeriods { get; set; }
		public virtual DbSet<SignalDB> Signals { get; set; }
		public virtual DbSet<DiscreteValueToStateDB> DiscreteValueToStates { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AnalogSignalMappingDB>()
				.Property(e => e.mapping_name)
				.IsUnicode(false);

			modelBuilder.Entity<CronExpressionDB>()
				.Property(e => e.cron_name)
				.IsUnicode(false);

			modelBuilder.Entity<DiscreteSignalMappingDB>()
				.Property(e => e.mapping_name)
				.IsUnicode(false);

			modelBuilder.Entity<RtuDB>()
				.Property(e => e.rtu_name)
				.IsUnicode(false);

			modelBuilder.Entity<RtuDB>()
				.Property(e => e.ip_address)
				.IsUnicode(false);

			modelBuilder.Entity<ScanPeriodDB>()
				.Property(e => e.scan_name)
				.IsUnicode(false);

			modelBuilder.Entity<SignalDB>()
				.Property(e => e.signal_name)
				.IsUnicode(false);

			modelBuilder.Entity<DiscreteValueToStateDB>()
				.Property(e => e.discrete_state)
				.IsUnicode(false);
		}
	}
}
