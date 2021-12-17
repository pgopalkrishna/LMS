using System;
using System.ComponentModel.DataAnnotations;
using LMS.Enums;
namespace LMS.Models
{
    public class LeaveRule
    {
        public int Id { get; set; }
        [Required]
        public int LeaveId { get; set; }
        [Required]
        public double NoOfLeaves { get; set; }
        [Required]
        public LeaveValidityEnum LeaveValidity { get; set; }
        public bool IsCarryForward { get; set; }
        
        public double CarryforwardCap { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
