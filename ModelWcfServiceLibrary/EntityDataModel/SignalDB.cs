namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignalDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SignalDB()
        {
            AnalogSignalMappings = new HashSet<AnalogSignalMappingDB>();
            DiscreteSignalMappings = new HashSet<DiscreteSignalMappingDB>();
        }

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

        public int rtu_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnalogSignalMappingDB> AnalogSignalMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscreteSignalMappingDB> DiscreteSignalMappings { get; set; }

        public virtual RtuDB Rtu { get; set; }
    }
}
