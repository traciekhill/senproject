using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace senproject.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Report[] Reports { get; set; }
        public Decimal ReportAverage { get; set; }
    }
}