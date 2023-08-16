namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CronExpressionDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cron_id { get; set; }

        [Required]
        [StringLength(255)]
        public string cron_name { get; set; }

        public DateTime cron_start { get; set; }

        public DateTime cron_end { get; set; }

        public int recurrence_period { get; set; }

        public int recurrence_type { get; set; }
    }
}
