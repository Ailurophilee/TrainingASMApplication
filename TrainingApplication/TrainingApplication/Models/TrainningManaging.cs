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
    
    public partial class TrainningManaging
    {
        public int TrainingManagingID { get; set; }
        public Nullable<int> TrainingStaffID { get; set; }
        public Nullable<int> TraineeID { get; set; }
        public Nullable<int> CourseCateID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> TopicID { get; set; }
        public Nullable<int> TrainerID { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual CourseCate CourseCate { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Trainee Trainee { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual TrainingStaff TrainingStaff { get; set; }
    }
}
