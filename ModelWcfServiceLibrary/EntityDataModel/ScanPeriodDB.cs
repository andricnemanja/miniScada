namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScanPeriodDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int scan_id { get; set; }

        [Required]
        [StringLength(255)]
        public string scan_name { get; set; }

        public TimeSpan scan_period { get; set; }
    }
}
