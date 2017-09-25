using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryManagementSystem.Models
{
    public class AccessionRecord
    {
        public int AccessionRecordId { get; set; }
        [Required]
        public Item Item { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string Source { get; set; }
        public int Price { get; set; }
    }
}