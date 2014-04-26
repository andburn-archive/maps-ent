Enterprise Frameworks Project
=======================

Andrew 
Fiona - 13121693
Adam  - 

------
1. Background research and investigations
2. Project Plan
 - Due care should be taken to accurately record details of which team member was assigned responsibility for each activity
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


Project plan see appendix I. This includes a description of all tasks identified and explained. It also shows resource allocation and timelines.


##3. Software development methodology employed, requirements analysis
Development Methodology

### Waterfall ###
(insert image of water here , image is created)


1. **Requirement Gathering and analysis**: All possible requirements of the system to be developed are captured in this phase and documented in a requirement specification doc.
1. **System Design**: The requirement specifications from first phase are studied in this phase and system design is prepared. System Design helps in specifying hardware and system requirements and also helps in defining overall system architecture.
1. ** Implementation:** With inputs from system design, the system is first developed in small programs called units, which are integrated in the next phase. Each unit is developed and tested for its functionality which is referred to as Unit Testing.
1. **Integration and Testing**: All the units developed in the implementation phase are integrated into a system after testing of each unit. Post integration the entire system is tested for any faults and failures.
1. **Deployment** of system: Once the functional and non functional testing is done, the product is deployed in the customer environment or released into the market.
1. **Maintenance**: There are some issues which come up in the client environment. To fix those issues patches are released. Also to enhance the product some better versions are released. Maintenance is done to deliver these changes in the customer environment.

### Waterfall Model Pros & Cons ###

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


##4. Use cases

(Alter user requirements) - asssign to fiona - fella to review
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

