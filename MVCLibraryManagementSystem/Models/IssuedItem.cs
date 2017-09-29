using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryManagementSystem.Models
{
    public class IssuedItem
    {
        public int IssuedItemId { get; set; }
        [Required]
        public virtual AccessionRecord AccessionRecord { get; set; }
        [Required]
        public virtual Member Member { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateReturned { get; set; }
        public int LateFeePerDay { get; set; }
        public bool IsIssued { get; set; }
    }
}