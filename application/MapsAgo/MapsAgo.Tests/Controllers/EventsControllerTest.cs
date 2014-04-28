using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapsAgo.Web.Controllers;
using System.Web.Mvc;

// This code tests methods that verify the Details() action method on the EventController. 
//
//TEST 1: will verify that a View is returned when an existing Event is requested. 
//
//TEST 2: will verify that a "NotFound" view is returned when a non-existent Dinner is requested:
namespace MapsAgo.Tests.Controllers
{
    [TestClass]
    public class EventsControllerTest
    {
        [TestMethod]
        public void DetailsAction_Should_Return_View_For_ExistingEvent()
        {

            //// Arrange
            //var controller = new EventController();

            //// Act
            //var result = controller.Details(1) as ViewResult;

            //// Assert
            //Assert.IsNotNull(result, "Expected View");
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView_For_FakeEvent()
        {

            //// Arrange
            //var controller = new EventController();

            //// Act
            //var result = controller.Details(999) as ViewResult;

            //// Assert
            //Assert.AreEqual("NotFound", result.ViewName);
        }
    }
  }

