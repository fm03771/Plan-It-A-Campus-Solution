//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanIt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events_has_Member
    {
        public int idEvents_has_Member { get; set; }
        public int Club_member_idClub_members { get; set; }
        public int Events_idEvents { get; set; }
        public string Why { get; set; }
    
        public virtual Club_member Club_member { get; set; }
        public virtual Event Event { get; set; }
    }
}
