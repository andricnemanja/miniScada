namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DiscreteSignalMappingDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscreteSignalMappingDB()
        {
            DiscreteValueToStates = new HashSet<DiscreteValueToStateDB>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mapping_id { get; set; }

        [Required]
        [StringLength(255)]
        public string mapping_name { get; set; }

        public int signal_id { get; set; }

        public virtual SignalDB Signal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscreteValueToStateDB> DiscreteValueToStates { get; set; }
    }
}
