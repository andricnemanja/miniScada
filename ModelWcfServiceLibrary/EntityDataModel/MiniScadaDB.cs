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

		public virtual DbSet<DbCronExpression> DbCronExpressions { get; set; }
		public virtual DbSet<DbDiscreteValueToState> DbDiscreteValueToStates { get; set; }
		public virtual DbSet<DbMapping> DbMappings { get; set; }
		public virtual DbSet<DbRtu> DbRtus { get; set; }
		public virtual DbSet<DbScanPeriod> DbScanPeriods { get; set; }
		public virtual DbSet<DbSignal> DbSignals { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DbCronExpression>()
				.Property(e => e.cron_name)
				.IsUnicode(false);

			modelBuilder.Entity<DbDiscreteValueToState>()
				.Property(e => e.discrete_state)
				.IsUnicode(false);

			modelBuilder.Entity<DbMapping>()
				.Property(e => e.mapping_name)
				.IsUnicode(false);

			modelBuilder.Entity<DbRtu>()
				.Property(e => e.rtu_name)
				.IsUnicode(false);

			modelBuilder.Entity<DbRtu>()
				.Property(e => e.ip_address)
				.IsUnicode(false);

			modelBuilder.Entity<DbScanPeriod>()
				.Property(e => e.scan_name)
				.IsUnicode(false);

			modelBuilder.Entity<DbSignal>()
				.Property(e => e.signal_name)
				.IsUnicode(false);
		}
	}
}
