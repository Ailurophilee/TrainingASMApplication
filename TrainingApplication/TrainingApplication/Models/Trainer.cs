//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            this.TrainningManagings = new HashSet<TrainningManaging>();
        }
    
        public int TrainerID { get; set; }
        public string TrainerUserID { get; set; }
        public string TrainerName { get; set; }
        public string Education { get; set; }
        public string WorkingPlace { get; set; }
        public Nullable<int> Telephone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> External { get; set; }
        public Nullable<bool> Internal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainningManaging> TrainningManagings { get; set; }
    }
}
