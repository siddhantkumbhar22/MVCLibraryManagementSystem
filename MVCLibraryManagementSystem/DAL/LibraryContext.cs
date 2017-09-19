using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCLibraryManagementSystem.Models;

namespace MVCLibraryManagementSystem.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("Library")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<QuestionPaper> QuestionPapers { get; set; }
        public DbSet<AccessionRegister> AccessionRegister { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<IssuedItem> IssuedItems { get; set; }
    }
}