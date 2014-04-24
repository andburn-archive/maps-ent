Enterprise Frameworks Project
=======================

1. Background research and investigations
2. Project Plan
 Due care should be taken to accurately record details of which team member was assigned re-
sponsibility for each activity
3. Software development methodology employed o Requirements analysis
4. Use cases
5. Architecture/Design approach
6. Models (Class Models / Data Models etc.)
7. Implementation of particular OOP constructs
8. Design patterns and architectural patterns implemented in the application
9. ORM tool usage
10. Dependency injection / IoC container usage
11. How cross-cutting concerns have been handled
12. Security of the application
13. Configuration of the application
14. Scalability of the application
15. Testing Approach (in terms of both functional and non-functional requirements)
16. Other relevant features of the application


////////////////////////////////////////////////////////////////////////////////////////////////////////////



##1. Background research and investigations

(slot in  )
##2. Project Plan

(Frame of ms project created)
 Due care should be taken to accurately record details of which team member was assigned re-
sponsibility for each activity
##3. Software development methodology employed, requirements analysis
(Adam has done research on this)

###Azure Deployment

For information regarding azure "virtual machine" vs. "websites" see disambiguation [here][azure-lingo]. The key points were that websites are platform as a service while virtual machines are like AWS EC2 and have to be configured manually. Websites suit us.

To start a new project with Azure already connected the procedure is as follows:

Process: `new project`[^1] -> `Check azure option` -> `choose websites` ->

[^!1]: New .NET 4.5.1 MVC5 with API and unit tests 

###ASP.NET Web API 2
(NOTES from tutorial ,write to fit doc)

[Tutorial](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api)


"A model is an object that represents the data in your application. 

ASP.NET Web API can automatically serialize your model to JSON, XML, or some other format, and then write the serialized data into the body of the HTTP response message. 

As long as a client can read the serialization format, it can deserialize the object.

 Most clients can parse either XML or JSON. Moreover, the client can indicate which format it wants by setting the Accept header in the HTTP request message."


##4. Use cases

??


##5. Architecture/Design approach


##6. Models (Class Models / Data Models etc.)

(Andrew to write here about Models to Date)

###2 different types of data models :

1. Database Model(link for now, hard code when finalised)
[Database Samples](https://github.com/andburn/maps-ent/blob/master/documentation/DatabaseSample.md)


2. Overview of data modeling context: 
![Bilby Stampede](http://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Data_modeling_context.svg/500px-Data_modeling_context.svg.png)

(we may need to create our own version)

##7. Implementation of particular OOP constructs

##8. Design patterns and architectural patterns implemented in the application

##9. ORM tool usage


##10. Dependency injection / IoC container usage

Write about 
##11. How cross-cutting concerns have been handled

????
##12. Security of the application

Authentication here? 
CAn we speak about  Roles here?

##13. Configuration of the application

???
##14. Scalability of the application

??
##15. Testing Approach (in terms of both functional and non-functional requirements)

Traditional waterfall development model
    *White-box testing
        *???? API testing (application programming interface) – testing of the application using public and private APIs
     *Black-box testing
     *
###Testing Levels
Unit testing

Component interface testing

System testing

Acceptance testing 
##16. Other relevant features of the application, e.g.,


API talk about API here


   * use of client-side processing,
   *use of Ajax,
    *use of web services,
    *use of a worklow engine 
