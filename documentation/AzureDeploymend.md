Azure Deployment
=======================

For information regarding azure "virtual machine" vs. "websites" see disambiguation [here][azure-lingo]. The key points were that websites are platform as a service while virtual machines are like AWS EC2 and have to be configured manually. Websites suit us.

To start a new project with Azure already connected the procedure is as follows:

Process: `new project`[^1] -> `Check azure option` -> `choose websites` ->

Web API Tutorial (5mins max)
--------------

I also followed a [tutorial][asp-api] on establishing an API for a project. The main insights were:
* That it's really easy
* It should be in a separate solution but doesn't have to be. 
* A web api defaults to `api/controllername` and then it just has methods
* jQuery works great within the project scope for getting data through an API (relative urls)
* With Web API, by default nothing is made available, and you write code to explicitly make available only the data that you want to be available.

See [online sample][azure-test] for an idea.


<!-- =========== Footnotes =================== -->
[^!1]: New .NET 4.5.1 MVC5 with API and unit tests 

<!-- =========== Links ======================= -->

[azure-lingo]: http://www.developerfusion.com/article/148148/the-evolution-of-a-web-application-with-windows-azure/
[asp-api]: http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
[azure-test]: http://nci-testapi.azurewebsites.net