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
    public class AccessionRecordsControllerTests
    {

        // This is why Repos are needed, so that we don't access this directly
        // and we can mock data whenever we need to.
        private LibraryContext context = new LibraryContext();

        /// <summary>
        /// By default the AccessionRecords Index view doesn't list items. This makes sure it does
        /// </summary>
        [TestMethod]
        public void TestBookIndexHasItems()
        {
            AccessionRecordsController controller = new AccessionRecordsController();

            var viewResult = controller.Index() as ViewResult;

            IEnumerable<AccessionRecord> recordsReturned = (IEnumerable<AccessionRecord>)viewResult.Model;

            foreach (var AccessionRecord in recordsReturned)
            {
                Assert.IsNotNull(AccessionRecord.Item.Title);
            }
        }

        /// <summary>
        /// This code will not compile, however it needs to because Index neads a search searchString
        /// </summary>
        [TestMethod]
        public void TestAccessionRecordIndexHasSearch()
        {
            AccessionRecordsController controller = new AccessionRecordsController();

            // var viewResult = controller.Index(searchString: "Test") as ViewResult;
            // IEnumerable<AccessionRecord> recordsReturned = (IEnumerable<AccessionRecord>)viewResult.Model;
            // Collections.Assert.IsSubsetOf(recordsReturned, context.AccessionRecords.ToList());
        }

        /// <summary>
        /// This code will not compile, however it needs to because Index neads a search searchString
        /// </summary>
        [TestMethod]
        public void TestAccessionRecordIndexHasPagination()
        {
            AccessionRecordsController controller = new AccessionRecordsController();

            // var viewResult = controller.Index(3) as ViewResult;
            // IEnumerable<AccessionRecord> recordsReturned = (IEnumerable<AccessionRecord>)viewResult.Model;

            // Assert.AreEqual(10, recordsReturned.Count);
        }
    }
}
