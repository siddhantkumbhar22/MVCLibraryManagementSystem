using System;
using System.Linq;
using System.Diagnostics;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCLibraryManagementSystem.DAL;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.Controllers;

namespace MVCLibraryManagementSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            BooksController controller = new BooksController();

            Book b = new Book() { Item = new Item() { Title = "TestBook", Year = 1989 }, BookId = 1, BookType = BOOKTYPES.FICTION, Author = "TestAuthor" };

            ViewResult result = controller.Create(b) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestCreateViewWorks()
        {
            BooksController controller = new BooksController();

            

            var result = controller.Create(b);

            Debug.WriteLine(result);

            Assert.IsNotNull(result);
        }
    }
}
