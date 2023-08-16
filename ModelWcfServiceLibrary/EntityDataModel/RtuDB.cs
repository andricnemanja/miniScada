namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RtuDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RtuDB()
        {
            Signals = new HashSet<SignalDB>();
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
        public virtual ICollection<SignalDB> Signals { get; set; }
    }
}
