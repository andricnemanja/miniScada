using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelWcfServiceLibrary.EntityDataModel
{
    public partial class DbRtu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DbRtu()
        {
            DbSignals = new HashSet<DbSignal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rtu_id { get; set; }

        [Required]
        [StringLength(255)]
        public string rtu_name { get; set; }

        [Required]
        [StringLength(20)]
        public string ip_address { get; set; }

        public int rtu_port { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbSignal> DbSignals { get; set; }
    }
}
