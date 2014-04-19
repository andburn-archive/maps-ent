# Project Notes

- Are some locations considered equal (2.333, -1.222) == (2.3, -1.2) ?
- Can one event have many locations, or are such events too broad.

# General ASP.NET & Visual Studio Notes

- Bundling and Minification
 - create bundles in `App_Start\BundleConfig.cs`
 - To load in view add `@Styles.Render(“~/Content/css”)` and/or `@Styles.Render(~/bundles/js)` to `_Layout.cshtml`, the actual paths depend on the particular project.
- Formatting model properties in views with annonations e.g. `[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]`
- When updating references in one project make sure you do the same in other projects, don't forget unit test project

-----
 
# Notes on Francis' Moodle Posts

### Visual Studio Suggested Project Structure
Have a seperate project in your solution for:

- MVC stuff
- Models
 - for use with DI/IOC, the I in SOLID
- Tests
 - MSTest for Unit testing, WaitN for Integration testing
- Specs 
 - Specflow back end, jasmine front end
- Libraries 
 - as you use source control (git hub) you will find that some of your dependencies will be missing on other peoples systems, copying them to a separate project and referencing them here will solve this.

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
 
-----

### Videos & Tutorials

[Introducing ASP.NET MVC 5](https://www.youtube.com/watch?v=gxFtRdKr7CA)

[What's New for Web Developers in Visual Studio 2013](htps://www.youtube.com/watch?v=ivs_gp6deBE)

[Entity Framework 5 - Database First (first 5 mins)](https://www.youtube.com/watch?v=o-cV_fSNMqw)

[MVC3 - Database first](https://www.youtube.com/watch?v=7612KR9lv2Y)

[Officail Tutorial Site ASP.NET](http://www.asp.net/mvc/tutorials/mvc-5)

I hope this highlights how easy it is to build full apps with MVC5. But more importantly, I hope you can understand that because it is so easy, you really need to focus on proper specs and tests first. Spending the time there will save you a lot of time on actual development.

Remember that while you will learn how to code in C#. App development in ASP.Net MVC is NOT about the
language and coding. It is about the concepts and tools. If you find yourself stuck in code for more than an hour, go back to the higher level concept and do search on google or you tube. ie. If you are stuck on sorting a result set in a table, type something like C# MVC table sorting in YouTube. If you find anything that is much more than few (literally 2 or 3) lines of code (or 10 min video), your probably heading the wrong direction.

If you cant find what you are looking for in a 15 / 20 min video on YouTube (even that is too long) or a short article in a blog somewhere (less than 5 or 6 pages), it should be a big indicator that your probably heading the wrong direction.

There is a single line of code in Razor that you can use in your solution that will tie all Javascript and CSS files together and minify them so there is no disadvantage to doing this with regard to speed and optimisation and your app will be easier to maintain as a result. So instead of thinking about optimising your CSS and JavaScript / JQuery, think about organising it in a way that is easily maintainable and let the tools do the work of optimisation for you.