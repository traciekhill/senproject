//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace senproject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int UserId { get; set; }
        public decimal StarRating { get; set; }
        public System.TimeSpan ResolutionStartTime { get; set; }
        public System.TimeSpan ResolutionEndTime { get; set; }
        public System.DateTime Date { get; set; }
        public int Id { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
