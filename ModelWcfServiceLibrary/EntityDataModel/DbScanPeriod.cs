using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelWcfServiceLibrary.EntityDataModel
{
    public partial class DbScanPeriod
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
