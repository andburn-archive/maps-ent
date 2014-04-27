Enterprise Frameworks Project - maps-ent
=======================

An enterprise level application to manage the content for a map-based RIA and provide a Web API

-------

##About
Enterprise Frameworks Project, MSc in Web Technologies (NCI)

**Project Title**  | maps-ent
:----------------- | :---------------------
**Team Members**   | Andrew Burnett
&nbsp;             | Adam Harrington
&nbsp;             | Fiona McAndrew
**Tutor**          | Vikas Sahni
**Technologies**   | .NET MVC5 EF
&nbsp;             | C#
&nbsp;             | Azure
**Source**         | https://github.com/andburn/maps-ent
**URL**            | n/a
**Licence**        | n/a


Table of Contents
------
1. Background research and investigations
2. Project Plan
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

*Saturday 26 April - Important to include*
- Discuss any Patterns used
- Project Plan - tasks who did what and when

------

##1. Background research and investigations

(slot in  )
##2. Project Plan


Project plan see **appendix I**. This includes a description of all tasks identified and explained. It also shows resource allocation and timelines.


##3. Software development methodology employed 
Development Methodology

### Waterfall SDLC ###

![alt text](https://raw.githubusercontent.com/andburn/maps-ent/master/documentation/Technical_Report/screenshots/waterfall.PNG?token=5261006__eyJzY29wZSI6IlJhd0Jsb2I6YW5kYnVybi9tYXBzLWVudC9tYXN0ZXIvZG9jdW1lbnRhdGlvbi9UZWNobmljYWxfUmVwb3J0L3NjcmVlbnNob3RzL3dhdGVyZmFsbC5QTkciLCJleHBpcmVzIjoxMzk5MjA0ODUzfQ%3D%3D--ac20269e8e4b72818ca8d55dccba17c51112650b "Waterfall SDLC") 

1. **Requirement Gathering and analysis**: 
 - Project Scope is defined, 
 - Requirements specification:
 	- Functional,
 	- Interface requirements,
 	- Documentation Requirement.
1. **System Design**:
 The requirement specifications from first phase are studied in this phase and system design is prepared. The System Architecture is defined, which will then inform the specification of the system's Data and Non-Functional Requirements.
1. ** Implementation:** (TO DO)
1. **Integration and Testing**: (TO DO)
1. **Deployment** of system: Once the functional and non functional testing is done, the product is deployed.
1. **Maintenance** - Out of scope for this project.

### Waterfall Model Pros & Cons ##

| Pros                   				| Cons                 | 
| --------------------------------------|-----------------------| 
| Simple and easy to understand phases, therefore good for novice programmers |  High amounts of risk and uncertainty. 
| Easy to manage due to the rigidity of the model, each phase has specific deliverables and a review process.      |   High amounts of risk and uncertainty. |	
|Phases are processed and completed one at a time.| Cannot accommodate changing requirements.		
|Works well for smaller projects where requirements are very well understood.|  Adjusting scope during the life cycle can end a project.
|Well understood milestones.| Integration is traditionality done as at the very end, which doesn't allow identifying any technological or business bottleneck or challenges early. [^1]
|Easy to arrange tasks.| No working software is produced until late during the life cycle.	 


[^1]: Test deployment was undertaken during the development phase, as the systems needed to be tested.
(overlay a gantt chart)

## Requirements Analysis ##


##4. Use cases

(Alter user requirements) - asssign to fiona - fellas to review
??


##5. Architecture/Design approach

CODE FIRST , ENTITY DIAGRAMS, (andrew to lash in)
domain model directly maps to database.


freebase wont map to database

##6. Models (Class Models / Data Models etc.)

(Andrew to write here about Models to Date)

### Model Types

*Actual Models (Models)*

These are the model classes which actually communicate with the back end DB. There is some
things you can do on these that does not make sense to do elsewhere. Most importantly to note is
that here is where you can do certain server side validation, and where you usually include every field
in the DB tables even if they are not shown in the views).

*View Models (ViewModels)*

These are the model classes your views use. While you are still using strictly MVC, you can add a
ViewModel folder and copy your model classes into it. This gives you an ability to easily add client
side validation (yeah, were still on the server side but the tooling will generate automatically the
JavaScript needed on the client side if you let it) or to only show certain fields on your form but to still
have access to the full set of fields at the back end. 
 

###2 different types of Data Models :

1. **Database Model** (link for now, hard code when finalised)
[Database Samples](https://github.com/andburn/maps-ent/blob/master/documentation/DatabaseSample.md)




(we may need to create our own version)

##7. Implementation of particular OOP constructs

SOLID - 
we favoured compostite over inheritance. 

single responsiblity

repository pattern why we did not use it.

We used MVC

##8. Design patterns and architectural patterns implemented in the application

##9. ORM tool usage

Entiity frameworks - Andrew 

##10. Dependency injection / IoC container usage

maybe in the freebase section, as an example - andrew

##11. How cross-cutting concerns have been handled

????

logging , and maybe auth?  - andrew seems to know about this 

CAn we speak about  Roles here?


	

That is why we have used strictly typed view. 

##12. Security of the application

**For form authentication: there is a 2 part CSRF**

- In View, add a antiforgery token to the form

 `@html.AntiForgeryToken()`

- In Controller, valid that action which is an desination for the post

    `[ValidateAntiForgery]`

##13. Configuration of the application

(Web Config?)
(Could we speak about role, authentication here)

	user: JoeSoap
	password: testing
	//role assigned PendingUser 

	user: admin
    password: testing
	// role assigned admin

	user: RegisteredJoe
	password: testing
	// role assigned AuthorizedUser



???
##14. Scalability of the application

??


(Azure, cloud scability)

(Adam has done research on this)

###Azure Deployment - Move to another section.

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


##15. Testing Approach (in terms of both functional and non-functional requirements)

This project uses the waterfall development model testing approach. 
   
###Testing Levels
- Unit testing - how do you varify it?
- Component interface testing - does log in, button,etc work.
- System testing - scenerio based testing, based on user cases.
- Acceptance testing - out of scope for college project, lecuturer to do this


(Notes
System:
- White-box testing
- API testing (application programming interface) – testing of the application using public and private APIs  
- Black-box testing
)
##16. Other relevant features of the application, e.g.,


**API** - talk about API here

