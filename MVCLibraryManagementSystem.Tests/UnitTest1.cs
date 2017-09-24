using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;    
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
        public void TestCreateViewWorks()
        {
            BooksController controller = new BooksController();

            Book b = new Book() { Item = new Item() { Title = "TestBook", Year = 1989 }, BookType = BOOKTYPES.FICTION, Author = "TestAuthor" };

            var result = controller.Create(b) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        

    }
}
