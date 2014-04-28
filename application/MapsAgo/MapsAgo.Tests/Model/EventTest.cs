using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Model;
using MapsAgo.Model.Event;

// this code tests the Event model
// TEST 1 : Event Should Not Be Valid When Some Properties Incorrect
// 
// TEST 2 : Event Should Be Valid When All Properties Correct
namespace MapsAgo.Tests.Model
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Event_Should_Not_Be_Valid_When_Some_Properties_Incorrect()
        {
            //Arrange
            Event event = new Event(){
                Name = "Battle of Boyne",
                Excerpt = "USA",
                Description = "jfsdklfjslkdfjslkdfjsldfjsldfj sadsadasd",
                Source = "some source",
                //StartDate = "",
                //EndDate = "",
                //DateCreated = "",
                //DateCreated = "",
                //LastModified = "",
                // LocationId = "",
                //EventTypeId = "",
                ApplicationUserId = "Bogus"
                
            };
            // Act
            bool isValid = event.IsValid;

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Event_Should_Be_Valid_When_All_Properties_Correct(){
            //Arrange
            Event event = new Event()
            {
                Name = "Battle of Boyne",
                Excerpt = "USA",
                Description = "jfsdklfjslkdfjslkdfjsldfjsldfj sadsadasd",
                Source = "some source",
                //StartDate = "",
                //EndDate = "",
                //DateCreated = "",
                //DateCreated = "",
                //LastModified = "",
                // LocationId = "",
                //EventTypeId = "",
                ApplicationUserId = "Bogus"
            };
            // Act
            bool isValid = event.IsValid;

            //Assert
            Assert.IsFalse(isValid);
        }
    }
}
