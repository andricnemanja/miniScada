using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelWcfServiceLibrary.EntityDataModel
{
    public partial class DbMapping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DbMapping()
        {
            DbDiscreteValueToStates = new HashSet<DbDiscreteValueToState>();
            DbSignals = new HashSet<DbSignal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mapping_id { get; set; }

        public int mapping_type { get; set; }

        [Required]
        [StringLength(255)]
        public string mapping_name { get; set; }

        public float? K { get; set; }

        public float? N { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbDiscreteValueToState> DbDiscreteValueToStates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbSignal> DbSignals { get; set; }
    }
}
