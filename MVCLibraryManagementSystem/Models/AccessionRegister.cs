using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryManagementSystem.Models
{
    public class AccessionRegister
    {
        [Key]
        public int AccessionId { get; set; }
        public virtual Item Item { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string Source { get; set; }
        public decimal Price { get; set; }
    }
}