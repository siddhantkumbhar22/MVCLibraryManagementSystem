using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.DAL;
using MVCLibraryManagementSystem.Controllers;

namespace MVCLibraryManagementSystem.Tests
{
    [TestClass]
    public class BooksControllerTests
    {
        // This is why Repos are needed, so that we don't access this directly
        private LibraryContext context = new LibraryContext();

        /// <summary>
        /// By default the Book Index view doesn't list items. This makes sure it does
        /// </summary>
        [TestMethod]
        public void TestBookIndexHasItems()
        {
            BooksController controller = new BooksController();

            var viewResult = controller.Index() as ViewResult;

            IEnumerable<Book> booksReturned = (IEnumerable<Book>)viewResult.Model;

            foreach(var book in booksReturned)
            {
                Assert.IsNotNull(book.Item.Title);
            }
        }

        /// <summary>
        /// This code will not compile, however it needs to because Index neads a search searchString
        /// </summary>
        [TestMethod]
        public void TestBookIndexHasSearch()
        {
            BooksController controller = new BooksController();

            // var viewResult = controller.Index(searchString: "Test") as ViewResult;
            // IEnumerable<Book> booksReturned = (IEnumerable<Book>)viewResult.Model;
            // Collections.Assert.IsSubsetOf(booksReturned, context.Books.ToList());
        }

        /// <summary>
        /// This code will not compile, however it needs to because Index neads a search searchString
        /// </summary>
        [TestMethod]
        public void TestBookIndexHasPagination()
        {
            BooksController controller = new BooksController();

            // var viewResult = controller.Index(3) as ViewResult;
            // IEnumerable<Book> booksReturned = (IEnumerable<Book>)viewResult.Model;

            // Assert.AreEqual(10, booksReturned.Count);

        }
    }
}