using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLibraryManagementSystem.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(0, 2015)]
        public int Year { get; set; }
        public bool IsBooked { get; set; }
    }
}