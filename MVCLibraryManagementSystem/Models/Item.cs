using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibraryManagementSystem.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}