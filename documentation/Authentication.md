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


 **Setting up roles w/ AuthorizeAttribute Class**

 		//only authorized roles such as PendingUser, Admin and AuthorizedUser.
		[Authorize]
        public ActionResult Index()
        {
			ViewBag.Message = "This page gives a vague description of the application and user information about approval period";
            return View();
        }

		//only the Admin and AuthorizedUser users can view the Events page
        [Authorize(Roles = "Admin , AuthorizedUser")]
        public ActionResult Events()
        {
            ViewBag.Message = "Your application description page.";
			return View();
        }

        //only the admin should see this ApproveUser page
        [Authorize(Roles = "Admin")]
        public ActionResult ApproveUser()
        {
            ViewBag.Message = "Only the Admin should by able to ApproveUsers";
            return View();
        }
		
