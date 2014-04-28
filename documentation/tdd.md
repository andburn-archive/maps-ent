## Unit Testing ##

Unit testing are vital in the creation of a enterprise level web application, as the tests varify that the code that is built works as expected and operates correctly. The former holds short term advantages for the applications development.

There is also long time benifits of testing as they insure that changes to the code don't indvertently affect other parts of the system.



> "In an ASP.NET MVC application, controllers will interact with services or repositories to handle each request. As each piece is built, these interactions can be tested using unit tests to instill confidence that the system continues to work as new features are added or new versions of dependent libraries are supplied." (http://msdn.microsoft.com/en-us/library/hh404088.aspx#sec8)

### Setting up Unit Tests ###

All testing work is carried out in the `mapsago.Tests` section.
Visual studio provides a testing framework called 

All unit tests in this project a structured using the **"AAA"** testing pattern.

1. Arrange: Setup the unit being tested
1. Act: Exercise the unit under test and capture results
1. Assert: Verify the behavior

Add **comments** and meaningful **descriptions**.

Add a comments to the class that appropriately describe the business scenario leading to the tests, this will help focus the test as well as providing documentation for the application to be revisited at a later date.


### Testing ASP.NET MVC Models ###

In Mapsago.Tests
   
mkdir `Model`
mk a `EventTest.cs`

In EventTest.cs

	//TO DO Add test code here
	.......................................
	// This code tests the Event model
    //
    // TEST 1 : Event Should Not Be Valid When Some Properties Incorrect
    // 
    // TEST 2 : Event Should Be Valid When All Properties Correct

    

### Testing ASP.NET MVC Controllers ###


Open the Controllers folder
mk a `EventsControllerTest.cs`

In EventsControllerTest.cs

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
        public void DetailsAction_Should_Return_View_For_ExistingDinner()
        {

            //// Arrange
            //var controller = new EventController();

            //// Act
            //var result = controller.Details(1) as ViewResult;

            //// Assert
            //Assert.IsNotNull(result, "Expected View");
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView_For_BogusDinner()
        {

            //// Arrange
            //var controller = new EventController();

            //// Act
            //var result = controller.Details(999) as ViewResult;

            //// Assert
            //Assert.AreEqual("NotFound", result.ViewName);
        }
    }


TO DO: 
Let's look at a design pattern called "dependency injection" that can help us work around these issues and avoid the need to use a real database with our tests.


// talk to the guys about this.

BEST TUTORIAL: http://www.asp.net/mvc/tutorials/older-versions/nerddinner/enable-automated-unit-testing




