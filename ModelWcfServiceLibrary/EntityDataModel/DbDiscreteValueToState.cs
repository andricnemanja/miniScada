//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelWcfServiceLibrary.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DbDiscreteValueToState
    {
        public int value_to_state_id { get; set; }
        public byte discrete_value { get; set; }
        public string discrete_state { get; set; }
        public int mapping_id { get; set; }
    
        public virtual DbMapping DbMapping { get; set; }
    }
}
