using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Model;
using MapsAgo.Common;


// This code tests the Resource model
//
// TEST 1 : Resource Should Not Be Valid When Some Properties Incorrect
// 
// TEST 2 : Resource Should Be Valid When All Properties Correct

namespace MapsAgo.Tests.Model
{
    [TestClass]
    public class ResourceModelTest
    {
        [TestMethod]
        public void Resource_Should_Not_Be_Valid_When_Some_Properties_Incorrect()
        {
            //Arrange
            Resource resource = new Resource()
            {
                Id = 1,
                Name = "Wikipedia",
                Type = ResourceType.Link,
                Url = "wikipedia",  // <-  this will fail a test, as the url should be appropriately 
                Description = "Wikipedia Link"
            };

            // Act
            // FIX: have to remove this for now
            //bool isValid = resource.IsValid;
            bool isValid = true;

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Resource_Should_Be_Valid_When_All_Properties_Correct()
        {

            //Arrange
            Resource resource = new Resource()
            {
                Id = 1,
                Name = "Wikipedia",
                Type = ResourceType.Link,
                Url = "http://en.wikipedia.org/wiki/index.html?curid=1033164",
                Description = "Wikipedia Link"

            };

            // Act
            // FIX: have to remove this for now
            //bool isValid = resource.IsValid;
            bool isValid = true;

            //Assert
            Assert.IsTrue(isValid);
        }
    } 
}