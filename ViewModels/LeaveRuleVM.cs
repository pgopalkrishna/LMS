using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class LeaveRuleVM
    {
        public int Id { get; set; }
        
        public string LeaveType { get; set; }
        
        public double NoOfLeaves { get; set; }
        
        public string ForPeriod { get; set; }
        public bool IsCarryForward { get; set; }

        public double CarryforwardCap { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
