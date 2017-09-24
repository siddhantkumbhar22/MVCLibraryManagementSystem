using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibraryManagementSystem.Models
{
    public class IssuedItem
    {
        public int IssuedItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Member Member { get; set; }
        public DateTime IssueDate { get; set; }
        public int LateFeePerDay { get; set; }
    }
}