using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.Controllers;
using MVCLibraryManagementSystem.DAL;
using Moq;

namespace MVCLibraryManagementSystem.Tests
{
    [TestClass]
    public class IssuedItemServiceTests
    {
        // We're testing IssuedItemService, so we need a fake IAccessionRecordService
        Mock<IAccessionRecordService> accRecMock = new Mock<IAccessionRecordService>(MockBehavior.Loose);
        List<IssuedItem> issuedItems = new List<IssuedItem>();

        Item item = new Item() { Title = "Item To Issue", ItemId = 1 };
        List<AccessionRecord> accessionRecords = new List<AccessionRecord>();
        Member member = new Member() { Name = "Test Member", MemberId = 100, MemberType = MEMBERTYPE.FACULTY };

        //TODO:
        // Test Default Values
        // Test that Service has GetDueDate and GetLateFee methods


        [TestInitialize]
        public void Init()
        {
            accessionRecords = new List<AccessionRecord>()
            {
                new AccessionRecord() {Item = item, AccessionRecordId = 10},
                new AccessionRecord() {Item = item, AccessionRecordId = 11},
                new AccessionRecord() {Item = item, AccessionRecordId = 12},
                new AccessionRecord() {Item = item, AccessionRecordId = 13}
            };

            issuedItems = new List<IssuedItem>()
            {
                new IssuedItem() { AccessionRecord = accessionRecords[0], LateFeePerDay = 5, Member = member, IssuedItemId = 20 },
                new IssuedItem() { AccessionRecord = accessionRecords[1], LateFeePerDay = 5, Member = member, IssuedItemId = 21 },
                new IssuedItem() { AccessionRecord = accessionRecords[2], LateFeePerDay = 5, Member = member, IssuedItemId = 22 },
                new IssuedItem() { AccessionRecord = accessionRecords[3], LateFeePerDay = 5, Member = member, IssuedItemId = 23 },
            };


            // Set up Item Mock
            accRecMock.Setup(m => m.GetAllAccessionRecords()).Returns(accessionRecords);
        }

        [TestMethod]
        public void TestGetUnIssuedAccRecords()
        {
            // This adds an accession record for a copy that is issued, so it should not be in the
            // list of records that is issued.
            accessionRecords.Add(new AccessionRecord() { Item = item, AccessionRecordId = 19 });

            issuedItems.Add(new IssuedItem() { AccessionRecord = accessionRecords.Last(), LateFeePerDay = 0, Member = member, IssuedItemId = 29, IsIssued = true });

            IIssuedItemService service = new IssuedItemService(accRecMock.Object);

            Assert.IsFalse(service.GetAllUnissuedAccRecords().Contains(accessionRecords.Last()));
        }


    }
}
