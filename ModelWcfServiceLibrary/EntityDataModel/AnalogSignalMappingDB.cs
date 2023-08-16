namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnalogSignalMappingDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mapping_id { get; set; }

        [Required]
        [StringLength(255)]
        public string mapping_name { get; set; }

        public float K { get; set; }

        public float N { get; set; }

        public int signal_id { get; set; }

        public virtual SignalDB Signal { get; set; }
    }
}
