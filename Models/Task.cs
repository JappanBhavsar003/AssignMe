//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssignMe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public long TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TaskAssignUserIDs { get; set; }
        public bool IsComplete { get; set; }
        public Nullable<System.DateTime> CompletedDT { get; set; }
        public long CompletedByUserID { get; set; }
        public bool IsOverdue { get; set; }
        public System.DateTime TaskDueDT { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedDT { get; set; }
    }
}
