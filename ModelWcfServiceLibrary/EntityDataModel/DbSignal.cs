using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelWcfServiceLibrary.EntityDataModel
{
    public partial class DbSignal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int signal_id { get; set; }

        [Required]
        [StringLength(255)]
        public string signal_name { get; set; }

        public int signal_address { get; set; }

        public float deadband { get; set; }

        public TimeSpan stale_time { get; set; }

        public int access_type { get; set; }

        public int signal_type { get; set; }

        public int? discrete_signal_type { get; set; }

        public int mapping_id { get; set; }

        public int rtu_id { get; set; }

        public virtual DbMapping DbMapping { get; set; }

        public virtual DbRtu DbRtu { get; set; }
    }
}
