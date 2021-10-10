//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BatchDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BatchDetail()
        {
            this.AssociateDetails = new HashSet<AssociateDetail>();
            this.TrainerDetails = new HashSet<TrainerDetail>();
        }

        [Key]
        [Required(ErrorMessage = "This field can must be full")]
        public string training_module_id { get; set; }
        [Required(ErrorMessage = "This field can must be full")]
        public Nullable<int> business_unit_id { get; set; }
        [Required(ErrorMessage = "This field can must be full")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> startdate { get; set; }
        [Required(ErrorMessage = "This field can must be full")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> enddate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateDetail> AssociateDetails { get; set; }
        public virtual TrainingModule TrainingModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainerDetail> TrainerDetails { get; set; }
    }
}
