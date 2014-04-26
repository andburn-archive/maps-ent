## Authentication ##

3 Different types for ASP.NET MVC 4

1. Forms Authentication

2. OpenID / OAuth

3. Windows Authentication


**Forms Authenitication** is suitable for Internet apps, is highly customisable; the developer of the site can control how the form looks and the password strength.

It relies on cookies by default. The cookie is stored in the clients browser so that they do not need to sign in again during a session.

SSL is required to make form authentication secure. Unless the site is hosted on a https address, instead of a regular http address, the username and password will be sent in plain text, making it vunerable.

**OpenID / OAuth** is also suitable for Internet applications. Third Party Indentity Providers authenticates a user and then redirects the user back to the ASP.NET MVC 4 site with a message verifing that they are who they say they are.

**Windows Authentication** is best suited to intranet application within an organisation. Users of the will avail of the "IntegratedAuth" provided by Mircosoft and will take advantage of a Single sign on.


| Authentication         | Internet apps | Features  | Suitable for Application |
| ---------------------- |:-------------:| -----:|  -----:
| Forms Authentication   | yes		 | SSL required, supplies cookies |  yes
| OpenID / OAuth         | yes	  		 |  Third Party Indentity Providers  |  yes
| Windows Authentication | no  			 |   "IntegratedAuth" provided by Mircosoft  |no


Forms Authentication  was choosen as the most appropriate Authentication implementation type for this application.

## Roles ##

This web application requires users to register and be approved by an admin before the users are granted access to site.

There are 3 types of roles in this application.

Role 		| Description 
---- 	| --- 
PendingUser | **PendingUser** are users awaiting approval by the **administrator**. |
AuthorizedUser | **AuthorizedUser** are Data Curators who are concerned with sourcing, managing and approval of data from third party sources for use in the application.
Admin | The **Administrator** is the overarching owner of the application. This user is concerned with how the system works together and with managing and approving Data Curators (ApprovedUser).





###Setting up roles w/ AuthorizeAttribute Class###

Change database config (write up later)

Launch application, if database is not present setup the following users:

	user: JoeSoap
	password: testing
	//role assigned PendingUser 

	user: admin
    password: testing
	// role assigned admin

	user: RegisteredJoe
	password: testing
	// role assigned AuthorizedUser

**Step 0:**
In the table **AspNetRoles** assign the following:

id		| Name |
---- 	| --- 
1 | PendingUser|
2| Admin|
3 | AuthorizedUser|

In the table **AspNetUserRoles** assign the following:

Userid							| Name |
---- 							| --- 
<\id of an Admin user\> 		| 2	|
<\id of an AuthorizedUser user\>| 3	|

(note a PendingUser does not need to be assigned a role, as everyone who registers is assigned the PendingUser status by default (id 1) )


**Step 1:**
Add a filter to the `FilterConfig` file in the `App_Start folder`. 
This filter will require a user to login to use the functionality of the web application.
Add: `filters.Add(new AuthorizeAttribute());`

**Step 2:**
Add  `[Authorize]` to HomeController

 		//only authorized roles such as PendingUser, Admin and AuthorizedUser.
		[Authorize]
		public class HomeController : Controller
		{
			 //code ommitted
		}

**Step 3:**
Add  ` [Authorize(Roles = "Admin , AuthorizedUser")]` to EventController
		

		//only the Admin and AuthorizedUser users can view the Events page
        [Authorize(Roles = "Admin , AuthorizedUser")]
        public ActionResult Index()
        {
           //code ommitted
        }

		
**Step 4:**  
Update **_Layout.cshtml** to only show application links if the site user `isAuthenticated`
		
    @using Microsoft.AspNet.Identity
    @if (Request.IsAuthenticated)
    {
    <li>@Html.ActionLink("Home", "Index", "Home")</li>
    <li>@Html.ActionLink("About", "About", "Home")</li>
    <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
    <li>@Html.ActionLink("Events", "Index", "Event")</li>
    }
    else
    {
    //no link options are dislayed
    }


