using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.DAL;
using MVCLibraryManagementSystem.Controllers;
using Moq;

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
        /// An Accession Record cannot be created for an Item that doesn't exist. Therefore a new Accession Record must
        /// already have an Item associated with it. This makes sure that the Create GET action method takes an ItemId.
        /// This test will not compile otherwise.
        /// </summary>
        [TestMethod]
        public void TestCreateTakesItemId()
        {
            var mock = new Mock<IAccessionRecordService>();
            mock.Setup(m => m.GetItemService().GetItemById(It.IsAny<Int32>())).Returns(new Item{ Title = "Test", ItemId = 1});

            AccessionRecordsController controller = new AccessionRecordsController(mock.Object);
            var result = controller.Create(itemid: 1);
        }

        /// <summary>
        /// Make sure that when a Create View is called with ItemId, that item id is added to the model that will be created.
        /// See documentation for TestCreateTakesItemId() for more details.
        /// </summary>
        [TestMethod]
        public void TestCreateHasProperModel()
        {
            var mock = new Mock<IAccessionRecordService>();
            mock.Setup(m => m.GetItemService().GetItemById(It.IsAny<Int32>())).Returns(new Item { Title = "Test", ItemId = 1 });

            AccessionRecordsController controller = new AccessionRecordsController(mock.Object);
            var result = controller.Create(1) as ViewResult;
            var newRecord = result.Model as AccessionRecord;

            Assert.IsNotNull(newRecord.Item);
            Assert.IsNotNull(newRecord.DateOfReceipt);
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
