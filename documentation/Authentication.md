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

## Roles ##
 **Setting up roles w/ AuthorizeAttribute Class**

Many Web applications require users to log in before the users are granted access to restricted content. In some applications, even users who are logged in might have restrictions 
on what content they can view or what fields they can edit.

To restrict access to an ASP.NET MVC view, you restrict access to the action method that renders the view. To accomplish this, the MVC framework provides the AuthorizeAttribute class.


I suggest you to use **[Authorize(Roles="Role1,Role2")] **[http://msdn.microsoft.com/en-us/library/](http://msdn.microsoft.com/en-us/library/)**system.web.mvc.authorizeattribute.aspx** to restrict users with specific roles to some actions or a controller
. 

Personally i don't use strings but an Enum passed to Roles="" and you can do it making your own **MyAuthorizeAttribute** deriving from **AuthorizeAttribute** 

To approve the user activate him somehow, send him an activation email, approve him manually setting the IsActive in database to true or something. 

Also don't use default Membership database, make your own and derive your membership and role classes from     **MembershipProvider** [http://msdn.microsoft.com/en-us/library/system.web.security.membershipprovider.aspx](http://msdn.microsoft.com/en-us/library/system.web.security.membershipprovider.aspx) and **RoleProvider** [http://msdn.microsoft.com/en-us/library/system.web.security.roleprovider.aspx](http://msdn.microsoft.com/en-us/library/system.web.security.roleprovider.aspx) .