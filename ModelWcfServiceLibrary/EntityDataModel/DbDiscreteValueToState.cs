using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelWcfServiceLibrary.EntityDataModel
{
    [Table("DbDiscreteValueToState")]
    public partial class DbDiscreteValueToState
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int value_to_state_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte discrete_value { get; set; }

        [Required]
        [StringLength(255)]
        public string discrete_state { get; set; }

        public int mapping_id { get; set; }

        public virtual DbMapping DbMapping { get; set; }
    }
}
