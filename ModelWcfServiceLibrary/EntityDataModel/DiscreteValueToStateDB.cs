namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscreteValueToState")]
    public partial class DiscreteValueToStateDB
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int value_to_state_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int discrete_value { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string discrete_state { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mapping_id { get; set; }

        public virtual DiscreteSignalMappingDB DiscreteSignalMapping { get; set; }
    }
}
