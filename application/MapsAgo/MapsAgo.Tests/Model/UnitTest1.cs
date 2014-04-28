using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Model;


// This code tests the Event model
//
// TEST 1 : Event Should Not Be Valid When Some Properties Incorrect
// 
// TEST 2 : Event Should Be Valid When All Properties Correct

namespace MapsAgo.Tests.Model
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Event_Should_Not_Be_Valid_When_Some_Properties_Incorrect()
        {

            ////Arrange
            //Event event = new Event()
            //{
            //    Id = 1,
            //    Name = "Test title",
            //    Excerpt =  "",
            //    Description = "",
            //    Source = "",
            //    StartDate = "",
            //    EndDate = "",
            //    DateCreated = "",
            //    LastModified = "",
            //    LocationId = "Bogus", // <--- this valid is not valid, as it should be a int, not a string
            //    EventTypeId = 0,
            //    ApplicationUserId = 0

            //};

            //// Act
            //bool isValid = event.IsValid;

            ////Assert
            //Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Event_Should_Be_Valid_When_All_Properties_Correct()
        {

            ////Arrange
            //Event event = new Event
            //{
            //    Id = 1,
            //    Name = "Test title",
            //    Excerpt =  "sdaljdlkasdj asdasdasd asdsda",
            //    Description = "sdsda asdlkj aklsdjaklsdj ad ajlskdjask  asd asd ad sd ad",
            //    Source = "www.example.com",
            // TO DO how are the following formatted?
            //    StartDate = "",
            //    EndDate = "",
            //    DateCreated = "",
            //    LastModified = "",
            //  END TO DO
            //    LocationId = 0,
            //    EventTypeId = 0,
            //    ApplicationUserId = 0
            //};

            //// Act
            //bool isValid = event.IsValid;

            ////Assert
            //Assert.IsTrue(isValid);
        }
    } 
}